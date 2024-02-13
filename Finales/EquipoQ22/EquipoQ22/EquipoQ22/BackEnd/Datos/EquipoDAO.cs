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
        public bool Crear(Equipo oEquipo)
         {
            bool resultado = true;
            SqlConnection cnn = HelperDB.ObtenerInstance().RecuperarConexión();
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                t = cnn.BeginTransaction();
                cmd.CommandText = "SP_INSERTAR_EQUIPO";
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = t;

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@pais", oEquipo.Pais);
                cmd.Parameters.AddWithValue("@director_tecnico", oEquipo.Director);

                SqlParameter pout = new SqlParameter();
                pout.ParameterName = "@id";
                pout.DbType = DbType.Int32;
                pout.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pout);

                cmd.ExecuteNonQuery();
                int nroEquipo = (int) pout.Value;

                SqlCommand cmd2;

                foreach (Jugador j in oEquipo.DetalleEquipo) {
                    cmd2 = new SqlCommand();
                    cmd2.CommandText = "SP_INSERTAR_DETALLES_EQUIPO";
                    cmd2.Connection = cnn;  
                    cmd2.Transaction = t;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id_equipo", nroEquipo);
                    cmd2.Parameters.AddWithValue("@id_persona", j.Persona.Id);
                    cmd2.Parameters.AddWithValue("@camiseta", j.Camiseta);
                    cmd2.Parameters.AddWithValue("@posicion", j.Posicion);
                    cmd2.ExecuteNonQuery();

                }


                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null) { t.Rollback(); }
            }


            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }

            return resultado;


         }

    }
}
