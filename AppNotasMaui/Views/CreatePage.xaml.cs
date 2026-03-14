using AppNotasMaui.Data;
using System.Collections.ObjectModel;
using AppNotasMaui.Models;
using AppNotasMaui.Views;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AppNotasMaui.Controls;

namespace AppNotasMaui.Views;

public partial class CreatePage : ContentPage
{
    private readonly DataContext _dataContext;
    public CreatePage(DataContext dataContext)
	{
        _dataContext = dataContext;
        InitializeComponent();
        
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Error", "El título  no pueden estar vacío.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(ContentEntry.Text))
        {
            await DisplayAlert("Error", "El contenido no pueden estar vacío.", "OK");
            return;
        }
        try
        {
            await _dataContext.Database.EnsureCreatedAsync();
            Nota newNota = new Nota
            {
                Id = 0,
                Title = TitleEntry.Text.Trim(),
                Content = ContentEntry.Text.Trim(),
                CreatedAt = DateTime.Now,
                IsFavorite = FavoriteCheck.IsChecked
            };
            await _dataContext.Notas.AddAsync(newNota);
            await _dataContext.SaveChangesAsync();

            await DisplayAlert("Éxito", "La nota se ha guardado correctamente.", "OK");
            await Navigation.PushAsync(new MainPage(_dataContext));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo guardar la nota: " + ex.Message, "OK");

        }
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(_dataContext));
    }
}