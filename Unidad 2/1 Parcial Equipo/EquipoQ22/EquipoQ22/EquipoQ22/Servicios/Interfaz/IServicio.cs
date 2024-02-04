using EquipoQ22.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Servicios.Interfaz
{
    public interface IServicio
    {   
        
        List<Persona> ObtenerPersonas();
        bool CrearEquipo(Equipo equipo);
      
    }
}
