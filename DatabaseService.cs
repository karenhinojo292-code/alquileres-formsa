using SQLite;


namespace alquileres_formsa;

public class DatabaseService
{
    private SQLiteAsyncConnection _conexion;

    private async Task Inicializar()
    {
        if (_conexion != null) return;

        var rutaDb = Path.Combine(FileSystem.AppDataDirectory, "alquileres.db3");
        _conexion = new SQLiteAsyncConnection(rutaDb);
        await _conexion.CreateTableAsync<Propiedad>();

        var cantidad = await _conexion.Table<Propiedad>().CountAsync();
        if (cantidad == 0)
        {
            await _conexion.InsertAllAsync(new List<Propiedad>
            {
                new Propiedad { Titulo = "Casa familiar", Ubicacion = "Formosa Capital", Precio = "$250.000", Imagen = "fondoo.jpg", Destacada = true },
                new Propiedad { Titulo = "Departamento moderno", Ubicacion = "Formosa Capital", Precio = "$180.000", Imagen = "foto_depa.jpg", Destacada = false }
            });
        }
    }

    public async Task<List<Propiedad>> ObtenerTodas()
    {
        await Inicializar();
        return await _conexion.Table<Propiedad>().ToListAsync();
    }

    public async Task<List<Propiedad>> Buscar(string filtro)
    {
        await Inicializar();
        var todas = await _conexion.Table<Propiedad>().ToListAsync();

        if (string.IsNullOrWhiteSpace(filtro))
            return todas;

        return todas
            .Where(p => p.Titulo.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                     || p.Ubicacion.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task Guardar(Propiedad propiedad)
    {
        await Inicializar();
        if (propiedad.Id != 0)
            await _conexion.UpdateAsync(propiedad);
        else
            await _conexion.InsertAsync(propiedad);
    }

    public async Task Eliminar(Propiedad propiedad)
    {
        await Inicializar();
        await _conexion.DeleteAsync(propiedad);
    }
}
