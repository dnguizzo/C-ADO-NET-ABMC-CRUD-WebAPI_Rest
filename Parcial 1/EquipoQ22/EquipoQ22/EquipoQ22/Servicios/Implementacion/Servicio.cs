using EquipoQ22.Datos;
using EquipoQ22.Dominio;
using EquipoQ22.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipoQ22.Datos.Interfaz;

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

      
        public List<Persona> ObtenerPersonas()
        {
            return dao.ObtenerPersonas();
        }

        
    }
}
