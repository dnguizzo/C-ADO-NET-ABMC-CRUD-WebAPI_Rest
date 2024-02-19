using Py_Final140222.Backend.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.Negocio
{
    interface IApp
    {
        //DataTable ConsultarProyectos();
        List<Proyecto> ConsultarProyectosPorFechas(DateTime since, DateTime until);
        Proyecto ConsultarProyectoPorID(int id);
        bool CerrarProyecto(int id, DateTime fec_baja);
    }
}
