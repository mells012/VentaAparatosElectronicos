using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace VentaAparatosElectronicos
{
    public partial class TrabajadoresPage : ContentPage
    {
        Trabajador _selectedItem;

        public TrabajadoresPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarTrabajadores();
        }

        private async Task CargarTrabajadores()
        {
            trabajadoresListView.ItemsSource = await AppDatabase.GetTrabajadoresAsync();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(puestoEntry.Text))
            {
                await DisplayAlert("Error", "Completa todos los campos.", "OK");
                return;
            }

            var t = new Trabajador
            {
                Nombre = nombreEntry.Text.Trim(),
                Puesto = puestoEntry.Text.Trim()
            };

            await AppDatabase.AddTrabajadorAsync(t);
            nombreEntry.Text = string.Empty;
            puestoEntry.Text = string.Empty;

            await CargarTrabajadores();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = e.SelectedItem as Trabajador;
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                await DisplayAlert("Error", "Selecciona un trabajador.", "OK");
                return;
            }

            await AppDatabase.DeleteTrabajadorAsync(_selectedItem);
            _selectedItem = null;
            trabajadoresListView.SelectedItem = null;

            await CargarTrabajadores();
        }
    }
}
