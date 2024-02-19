using Py_Final140222.Backend.datos;
using Py_Final140222.Backend.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.datos
{
    class ProyectoDAO : IDao
    {
      
        public List<Proyecto> ConsultarProyectosPorFechas(DateTime since, DateTime until)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            
            string sp = "SP_CONSULTAR_PROYECTOS_POR_FECHA";
            List<Parametro> param = new List<Parametro>();
            param.Add(new Parametro("fec_inicio", since));// enb comuillas los datos del sp
            param.Add(new Parametro("fec_fin", until));
            // ejecuto sp
            DataTable dt = HelperDAO.ObtenerInstancia().GetSQL(sp,param);
            
            foreach (DataRow item in dt.Rows) {
            
                // mapeo de dominios
                Proyecto oProyecto = new Proyecto();
                oProyecto.Nombre = item["nombre"].ToString();
                oProyecto.fechaFin = DateTime.Parse(item["fecha_fin"].ToString());
                oProyecto.fechaInicio= Convert.ToDateTime(item["fecha_inicio"].ToString());
                oProyecto.ProyectoId= Convert.ToInt32 (item["id_proyecto"].ToString());
                
                proyectos.Add(oProyecto);

               

            }

            return proyectos;


           
       
        }

        public bool CerrarProyecto(int id, DateTime fec_baja)
        {
            
            return HelperDAO.ObtenerInstancia().UpdateSQL("SP_CERRAR_PROYECTO",id,fec_baja);

            
        }
            

        public Proyecto ConsultarProyectoPorID(int id)
        {

            Proyecto oProyecto = new Proyecto();

            string sp = "SP_CONSULTAR_PROYECTOS_POR_ID";
            List<Parametro> param = new List<Parametro>();
            param.Add(new Parametro("@id_proyecto", id));// enb comuillas los datos del sp
            
            DataTable dt = HelperDAO.ObtenerInstancia().GetSQL(sp,param);
            // mapeo de datos 
            bool primero = true;
            foreach (DataRow item in dt.Rows)
            {
                //maestros del proyecto
                if (primero)
                {
                    oProyecto.ProyectoId = int.Parse(item["id_proyecto"].ToString());
                    oProyecto.Nombre = item["nombre"].ToString();
                    oProyecto.fechaInicio = DateTime.Parse(item["fecha_inicio"].ToString());
                    oProyecto.fechaFin = DateTime.Parse(item["fecha_fin"].ToString());
                    primero = false;
                }

                // mapeo de datos del detalle del proyecto
                int nro = int.Parse(item["id_empelado"].ToString());
                string nombre = item["nombre"].ToString();
                string apellido = item["apellido"].ToString();
                int dni = int.Parse(item["dni"].ToString());
                Empleado oEmpleado = new Empleado(nro, nombre, apellido,dni);

                int horas = int.Parse(item["hrsSemana"].ToString());
                string rol = item["rol"].ToString();

                DetalleRecurso detalle = new DetalleRecurso(oEmpleado, oProyecto.ProyectoId,rol,horas);
                oProyecto.AgregarRecurso(detalle);

            }

            

            return oProyecto;
         
        }
    }

}