using AppNotasMaui.Data;
using System.Collections.ObjectModel;
using AppNotasMaui.Models;
using AppNotasMaui.Views;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppNotasMaui.Views;

public partial class EditPage : ContentPage
{
	Nota NotaActual;
    bool _isfavorite;
    private readonly DataContext _dataContext;
    public EditPage(Nota nota, DataContext dataContext)
	{
		NotaActual = nota;
		_dataContext = dataContext;
        InitializeComponent();
        BindingContext = this; //MVVM panel
        LoadNote();
    }

    public async void LoadNote()
    {
        try
        {
            await _dataContext.Database.EnsureCreatedAsync();
            var nota = await _dataContext.Notas.FirstOrDefaultAsync(n => n.Id == NotaActual.Id);
            if (nota != null)
            {
                TitleEntry.Text = nota.Title;
                ContentEntry.Text = nota.Content;
                FavoriteCheck.IsChecked = nota.IsFavorite;
                _isfavorite = nota.IsFavorite;
            }
        }
        catch (Exception e)
        {
            await DisplayAlert("Error", "No se puedo cargar la nota:" + e, "Ok");
        }
    }

    public async void Save_Clicked(object sender, EventArgs e)
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
            var nota = await _dataContext.Notas.FirstOrDefaultAsync(n => n.Id == NotaActual.Id);
            if (nota != null)
            {
                nota.Title = TitleEntry.Text.Trim();
                nota.Content = ContentEntry.Text.Trim();
                nota.IsFavorite = FavoriteCheck.IsChecked;
                nota.UpdatedAt = DateTime.Now;
                _dataContext.Notas.Update(nota);
                await _dataContext.SaveChangesAsync();
                await DisplayAlert("Éxito", "La nota se ha actualizado correctamente.", "OK");
                await Navigation.PushAsync(new MainPage(_dataContext));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo actualizar la nota: " + ex.Message, "OK");
        }
    }

    public async void Delete_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nota = await _dataContext.Notas.FirstOrDefaultAsync(n => n.Id == NotaActual.Id);
            if (nota != null)
            {
                _dataContext.Notas.Remove(nota);
                await _dataContext.SaveChangesAsync();
                await DisplayAlert("Éxito", "La nota se ha eliminado correctamente.", "OK");
                await Navigation.PushAsync(new MainPage(_dataContext));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo eliminar la nota: " + ex.Message, "OK");
        }
    }

    public async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(_dataContext));
    }

    public async void FavoriteCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _isfavorite = e.Value;
        await DisplayAlert("Favorito", e.Value ? "La nota se marcará como favorita." : "La nota no se marcará como favorita.", "OK");
    }
}