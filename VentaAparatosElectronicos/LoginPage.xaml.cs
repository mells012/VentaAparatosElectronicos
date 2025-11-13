using Microsoft.Maui.Controls;
using System;

namespace VentaAparatosElectronicos
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text?.Trim();
            var password = passwordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Ingresa usuario y contraseña.", "OK");
                return;
            }

            var user = await AppDatabase.ValidarUsuarioAsync(username, password);

            if (user != null)
            {
                await Navigation.PushAsync(new MainPage(user.Username));
            }
            else
            {
                await DisplayAlert("Error", "Credenciales inválidas.", "OK");
            }
        }
    }
}
