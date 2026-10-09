namespace alquileres_formsa;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        if (txtCorreo.Text == "admin@gmail.com" &&
            txtPassword.Text == "1234")
        {
            await Navigation.PushAsync(new HomePage()); 
        }
        else
        {
            await DisplayAlert("Error",
                               "Datos incorrectos",
                               "Aceptar");
        }
    }

    private void IconOjo_Tapped(object sender, TappedEventArgs e)
    {
        txtPassword.IsPassword = !txtPassword.IsPassword;
        ojito.Text = txtPassword.IsPassword ? "👁" : "🙈";
    }
}
