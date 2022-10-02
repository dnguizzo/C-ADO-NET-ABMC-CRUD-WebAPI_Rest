using EquipoQ22.Datos.Implementacion;
using EquipoQ22.Datos;
using EquipoQ22.Domino;
using EquipoQ22.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IEquipoDao dao;

        public Servicio()
        {
            dao = new EquipoDao();
        }

       

        public bool CrearEquipo(Equipo equipo)
        {
            return dao.Crear(equipo);
        }

      
        public List<Persona> ObtenerPersona()
        {
            return dao.ObtenerPersonas();
        }

       

       
    }
}
