using AppNotasMaui.Data;
using System.Collections.ObjectModel;
using AppNotasMaui.Models;
using Microsoft.EntityFrameworkCore;


namespace AppNotasMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly DataContext _dataContext;

        public ObservableCollection<Nota> Notas { get; set; }

        public MainPage(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;
            Notas = new ObservableCollection<Nota>();
            BindingContext = this; //MVVM panel
            LoadNotes();
        }

        private async void LoadNotes()
        {
            try
            {
                await _dataContext.Database.EnsureCreatedAsync();
                var Notas = await _dataContext.Notas.ToListAsync();
                foreach (var nota in Notas)
                {
                    this.Notas.Add(nota);
                }
            }
            catch(Exception e)
            {

                await DisplayAlert("Error","No se puedo cargar las notas:" + e, "Ok");
            }
        }

    }
}
