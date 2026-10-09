
using Microsoft.Extensions.DependencyInjection;

namespace alquileres_formsa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        
    }
}