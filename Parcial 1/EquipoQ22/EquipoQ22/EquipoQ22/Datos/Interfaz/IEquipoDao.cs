using EquipoQ22.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Datos.Interfaz
{
    public interface IEquipoDao 
    {
        List<Persona> ObtenerPersonas();
        bool Crear(Equipo oEquipo);
    }
}
