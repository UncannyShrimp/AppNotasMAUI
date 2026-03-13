using AppNotasMaui.Data;
using System.Collections.ObjectModel;
using AppNotasMaui.Models;
using AppNotasMaui.Views;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePage(_dataContext));
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Nota nota)
            {
                await Navigation.PushAsync(new EditPage(nota, _dataContext));
            }
        }

    }
}
