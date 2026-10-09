namespace alquileres_formsa;

public partial class PublicarPage : ContentPage
{
    private readonly DatabaseService _db = new();
    private string _rutaFotoElegida;

    public PublicarPage()
    {
        InitializeComponent();
    }

    private async void OnElegirFotoClicked(object sender, EventArgs e)
    {
        try
        {
            var foto = await MediaPicker.Default.PickPhotoAsync();
            if (foto == null) return;

            var carpetaDestino = Path.Combine(FileSystem.AppDataDirectory, "fotos");
            Directory.CreateDirectory(carpetaDestino);

            var nombreArchivo = $"{Guid.NewGuid()}.jpg";
            var rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);

            using var streamOrigen = await foto.OpenReadAsync();
            using var streamDestino = File.Create(rutaFinal);
            await streamOrigen.CopyToAsync(streamDestino);

            _rutaFotoElegida = rutaFinal;
            imgPreview.Source = ImageSource.FromFile(rutaFinal);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar la foto: {ex.Message}", "OK");
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryTitulo.Text) ||
            string.IsNullOrWhiteSpace(entryUbicacion.Text) ||
            string.IsNullOrWhiteSpace(entryPrecio.Text))
        {
            await DisplayAlert("Faltan datos", "Completá al menos título, ubicación y precio.", "OK");
            return;
        }

        var nueva = new Propiedad
        {
            Titulo = entryTitulo.Text.Trim(),
            Ubicacion = entryUbicacion.Text.Trim(),
            Precio = entryPrecio.Text.Trim(),
            Imagen = _rutaFotoElegida ?? "",
            Destacada = switchDestacada.IsToggled
        };

        await _db.Guardar(nueva);

        await DisplayAlert("Listo", "Propiedad publicada correctamente.", "OK");

        await Navigation.PopAsync();
    }
}