using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace VentaAparatosElectronicos
{
    public partial class InventarioPage : ContentPage
    {
        InventarioItem _selectedItem;

        public InventarioPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarInventario();
        }

        private async Task CargarInventario()
        {
            inventarioListView.ItemsSource = await AppDatabase.GetInventarioAsync();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(cantidadEntry.Text) ||
                string.IsNullOrWhiteSpace(precioEntry.Text))
            {
                await DisplayAlert("Error", "Completa todos los campos.", "OK");
                return;
            }

            if (!int.TryParse(cantidadEntry.Text, out int cantidad) ||
                !decimal.TryParse(precioEntry.Text, out decimal precio))
            {
                await DisplayAlert("Error", "Cantidad y precio deben ser numéricos.", "OK");
                return;
            }

            var item = new InventarioItem
            {
                Nombre = nombreEntry.Text.Trim(),
                Cantidad = cantidad,
                Precio = precio
            };

            await AppDatabase.AddInventarioAsync(item);
            nombreEntry.Text = string.Empty;
            cantidadEntry.Text = string.Empty;
            precioEntry.Text = string.Empty;

            await CargarInventario();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = e.SelectedItem as InventarioItem;
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                await DisplayAlert("Error", "Selecciona un elemento para eliminar.", "OK");
                return;
            }

            await AppDatabase.DeleteInventarioAsync(_selectedItem);
            _selectedItem = null;
            inventarioListView.SelectedItem = null;

            await CargarInventario();
        }
    }
}
