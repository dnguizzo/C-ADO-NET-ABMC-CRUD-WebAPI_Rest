using EquipoQ22.BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Datos
{
    public interface InterfaceDAO
    {
        List<Persona> CargarPersonas();
        bool Crear(Equipo oEquipo);


    }
}
