using EquipoQ22.BackEnd.Datos;
using EquipoQ22.BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Negocio
{
    internal class GestorImp: InterfaceGestor
    {
        private InterfaceDAO dao;

        public GestorImp() { 
        
            dao = new EquipoDAO();
        }
        public List<Persona> CargarJugadores()
        {
            return dao.CargarPersonas(); 
        }
        public bool CrearEquipo(Equipo oEquipo)
        {
            return dao.Crear(oEquipo);
        }
    }
}
