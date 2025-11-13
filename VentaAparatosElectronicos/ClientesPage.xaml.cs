using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace VentaAparatosElectronicos
{
    public partial class ClientesPage : ContentPage
    {
        Cliente _selectedItem;

        public ClientesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarClientes();
        }

        private async Task CargarClientes()
        {
            clientesListView.ItemsSource = await AppDatabase.GetClientesAsync();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text))
            {
                await DisplayAlert("Error", "Completa todos los campos.", "OK");
                return;
            }

            var c = new Cliente
            {
                Nombre = nombreEntry.Text.Trim(),
                Email = emailEntry.Text.Trim()
            };

            await AppDatabase.AddClienteAsync(c);
            nombreEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;

            await CargarClientes();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = e.SelectedItem as Cliente;
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                await DisplayAlert("Error", "Selecciona un cliente.", "OK");
                return;
            }

            await AppDatabase.DeleteClienteAsync(_selectedItem);
            _selectedItem = null;
            clientesListView.SelectedItem = null;

            await CargarClientes();
        }
    }
}
