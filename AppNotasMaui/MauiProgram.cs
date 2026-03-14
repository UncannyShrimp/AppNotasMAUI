using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AppNotasMaui.Data;
using AppNotasMaui.Models;

namespace AppNotasMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<DataContext>(
            options =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "datos.db");
                options.UseSqlite($"Data Source={dbPath}");
            }
                );//Dependency Injection

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.EnsureCreated();
                if (!context.Notas.Any())
                {
                    context.Notas.AddRange(
                            new Nota { Id = 1, Title = "Nota uno", Content = "contenido", CreatedAt = DateTime.Now, IsFavorite = true },
                            new Nota { Id = 2, Title = "Nota dos", Content = "contenido ", CreatedAt = DateTime.Now, IsFavorite = false }
                    );
                    context.SaveChanges();
                }

            }
            return app;

            //return builder.Build();
        }
    }
}
