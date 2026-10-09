namespace alquileres_formsa
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnDashboardClicked(object sender, TappedEventArgs e)
        {
            await DisplayAlertAsync("Navegación", "Ya estás en el Dashboard", "OK");
        }

        private async void OnPropiedadesClicked(object sender, TappedEventArgs e)
        {
            await DisplayAlertAsync("Navegación", "Ir a Propiedades", "OK");
        }

        private async void OnContratosClicked(object sender, TappedEventArgs e)
        {
            await DisplayAlertAsync("Navegación", "Ir a Contratos", "OK");
        }

        private async void OnPublicarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublicarPage());
        }
        private async void OnClientesClicked(object sender, TappedEventArgs e)
        {
            await DisplayAlertAsync("Navegación", "Ir a Clientes", "OK");
            await Shell.Current.GoToAsync("//ClientesPage");

        }
        private async void OnBuscarClicked(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text?.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                await DisplayAlert("Atención", "Escribí una zona o barrio para buscar.", "OK");
                return;
            }

            await Navigation.PushAsync(new PropiedadesPage(texto));
        }




    }

}