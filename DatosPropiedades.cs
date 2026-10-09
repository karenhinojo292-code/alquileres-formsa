using System;
using System.Collections.Generic;
using System.Text;

namespace alquileres_formsa
{



    public static class DatosPropiedades
    {
        public static List<Propiedad> Todas = new()
    {
        new Propiedad
        {
            Titulo = "Casa familiar",
            Ubicacion = "Formosa Capital",
            Precio = "$250.000",
            Imagen = "fondoo.jpg",
            Destacada = true
        },
        new Propiedad
        {
            Titulo = "Departamento moderno",
            Ubicacion = "Formosa Capital",
            Precio = "$180.000",
            Imagen = "foto_depa.jpg",
            Destacada = false
        }
      };
    }
 }
