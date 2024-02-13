using EquipoQ22.BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Negocio
{
    interface  InterfaceGestor
    {
        List<Persona> CargarJugadores();
        bool CrearEquipo(Equipo oEquipo);
    }
}
