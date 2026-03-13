using AppNotasMaui.Data;
using System.Collections.ObjectModel;
using AppNotasMaui.Models;
using AppNotasMaui.Views;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppNotasMaui.Views;

public partial class CreatePage : ContentPage
{
    private readonly DataContext _dataContext;
    bool _isfavorite = false;
    public CreatePage(DataContext dataContext)
	{
        _dataContext = dataContext;
        InitializeComponent();
        
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _isfavorite = e.Value;
        await DisplayAlert("Favorito", _isfavorite ? "La nota se marcará como favorita." : "La nota no se marcará como favorita.", "OK");

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
                IsFavorite = _isfavorite
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