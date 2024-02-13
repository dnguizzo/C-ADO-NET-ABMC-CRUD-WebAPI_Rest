using EquipoQ22.BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Datos
{
    public class EquipoDAO : InterfaceDAO
    {
        public List<Persona> CargarPersonas()
        {

            List<Persona> lst = new List<Persona>();
            string sp = "SP_CONSULTAR_PERSONAS";
            DataTable dt = HelperDB.ObtenerInstance().GetSQL(sp, null);
            foreach (DataRow item in dt.Rows) {
                int id = int.Parse(item["id_persona"].ToString());
                string nombre = item["nombre_completo"].ToString();
                int clase = int.Parse(item["clase"].ToString());
                Persona oPersona = new Persona(id, nombre, clase);
                lst.Add(oPersona);
            }


            return lst;
        }



        public bool Crear( Equipo oEquipo) {

            return HelperDB.ObtenerInstance().InsertSQL("SP_INSERTAR_EQUIPO", "INSERTAR_DETALLE_EQUIPO",oEquipo);
        }
        

    }
}
