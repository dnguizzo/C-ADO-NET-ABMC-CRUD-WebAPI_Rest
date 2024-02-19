using Py_Final140222.Backend.datos;
using Py_Final140222.Backend.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.Negocio
{
    class ServiceApp: IApp
    {
        private IDao dao;

        public ServiceApp()
        {
            dao = new ProyectoDAO();
        }

        public bool CerrarProyecto(int id, DateTime fec_baja)
        {
             return dao.CerrarProyecto(id,fec_baja);
        }

        public Proyecto ConsultarProyectoPorID(int id)
        {
            return dao.ConsultarProyectoPorID(id);
        }

       
        public List<Proyecto> ConsultarProyectosPorFechas(DateTime since, DateTime until)
        {
            return dao.ConsultarProyectosPorFechas(since, until);
        }
    }
}
