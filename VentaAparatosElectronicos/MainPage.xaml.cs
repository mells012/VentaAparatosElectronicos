using Microsoft.Maui.Controls;
using System;

namespace VentaAparatosElectronicos
{
    public partial class MainPage : ContentPage
    {
        private string _username;

        public MainPage(string username)
        {
            InitializeComponent();
            _username = username;
            saludoLabel.Text = $"Bienvenido, {_username}";
        }

        private async void OnInventarioClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventarioPage());
        }

        private async void OnTrabajadoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrabajadoresPage());
        }

        private async void OnClientesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientesPage());
        }

        private async void OnFacturasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacturasPage());
        }
    }
}
