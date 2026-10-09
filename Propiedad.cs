using SQLite;

namespace alquileres_formsa;

public class Propiedad
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Titulo { get; set; }
    public string Ubicacion { get; set; }
    public string Precio { get; set; }
    public string Imagen { get; set; }
    public bool Destacada { get; set; }
}