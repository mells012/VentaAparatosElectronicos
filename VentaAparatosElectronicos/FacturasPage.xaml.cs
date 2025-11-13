using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace VentaAparatosElectronicos
{
    public partial class FacturasPage : ContentPage
    {
        Factura _selectedItem;

        public FacturasPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarFacturas();
        }

        private async Task CargarFacturas()
        {
            facturasListView.ItemsSource = await AppDatabase.GetFacturasAsync();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(clienteNombreEntry.Text) ||
                string.IsNullOrWhiteSpace(totalEntry.Text))
            {
                await DisplayAlert("Error", "Completa todos los campos.", "OK");
                return;
            }

            if (!decimal.TryParse(totalEntry.Text, out decimal total))
            {
                await DisplayAlert("Error", "El total debe ser numérico.", "OK");
                return;
            }

            var f = new Factura
            {
                ClienteNombre = clienteNombreEntry.Text.Trim(),
                Fecha = DateTime.Now,
                Total = total
            };

            await AppDatabase.AddFacturaAsync(f);
            clienteNombreEntry.Text = string.Empty;
            totalEntry.Text = string.Empty;

            await CargarFacturas();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = e.SelectedItem as Factura;
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                await DisplayAlert("Error", "Selecciona una factura.", "OK");
                return;
            }

            await AppDatabase.DeleteFacturaAsync(_selectedItem);
            _selectedItem = null;
            facturasListView.SelectedItem = null;

            await CargarFacturas();
        }
    }
}
