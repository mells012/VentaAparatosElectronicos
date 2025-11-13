using Microsoft.Maui.Controls;

namespace VentaAparatosElectronicos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Página inicial de navegación
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
