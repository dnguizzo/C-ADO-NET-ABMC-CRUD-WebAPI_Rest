using EquipoQ22.Domino;
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
        int ProximoPresupuesto();
        List<Persona> ObtenerPersonas();
        bool CrearEquipo(Equipo equipo);
      
    }
}
