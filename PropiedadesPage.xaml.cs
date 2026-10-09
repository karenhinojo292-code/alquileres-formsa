namespace alquileres_formsa;

public partial class PropiedadesPage : ContentPage
{
    public PropiedadesPage(string filtro = "")
    {
        InitializeComponent();

        var resultados = string.IsNullOrWhiteSpace(filtro)
            ? DatosPropiedades.Todas
            : DatosPropiedades.Todas
                .Where(p => p.Titulo.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                         || p.Ubicacion.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                .ToList();

        listaResultados.ItemsSource = resultados;

        Title = string.IsNullOrWhiteSpace(filtro) ? "Todas las propiedades" : $"Resultados: {filtro}";
    }
}