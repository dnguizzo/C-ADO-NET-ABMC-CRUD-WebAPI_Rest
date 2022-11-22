using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.Dominio;

namespace U2_Veterinaria.DAO.Singleton
{
    public class HelperDB
    {
        private static HelperDB instancia;
        private SqlConnection cnn;

        private HelperDB()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }
        public static HelperDB ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new HelperDB();
            return instancia;

        }

        public DataTable ConsultaSQL(string sp, List<Parametro> value)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            if (value != null)
            {
                foreach (Parametro item in value)
                {
                    cmd.Parameters.AddWithValue(item.Clave, item.Valor);

                }
            }
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }

        public bool CrearMascotaAtencion (string spMascota, string spAtencion, Mascota oMascota)
       
        {
            bool ok = true;
            SqlTransaction t = null;


            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_MASCOTA";
                cmd.CommandType = CommandType.StoredProcedure;
                // Parametros de entrada:
                cmd.Parameters.AddWithValue("id_mascota", oMascota.Id_Mascota);
                cmd.Parameters.AddWithValue("edad", oMascota.Id_Mascota);
                cmd.Parameters.AddWithValue("tipo", oMascota.Tipo.Id_tipo);
                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id_mascota";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int id_mascota = (int)pOut.Value;

                SqlCommand cmdAtencion = null;
                int atencionNro = 1;
                foreach (Atención item in oMascota.DetalleAtenciones)
                {
                    cmdAtencion = new SqlCommand();
                    cmdAtencion.Connection = cnn;
                    cmdAtencion.Transaction = t;
                    cmdAtencion.CommandText = "SP_INSERTAR_ATENCION";
                    cmdAtencion.CommandType = CommandType.StoredProcedure;
                    cmdAtencion.Parameters.AddWithValue("id_atencion", atencionNro);
                    cmdAtencion.Parameters.AddWithValue("fecha", atencionNro);
                    cmdAtencion.Parameters.AddWithValue("descripcion", atencionNro);
                    cmdAtencion.Parameters.AddWithValue("importe", atencionNro);
                    cmdAtencion.Parameters.AddWithValue("id_mascota", id_mascota);
                    cmdAtencion.ExecuteNonQuery();

                    atencionNro++;

                }

                t.Commit();
                ok = true;
            }

            catch (Exception e)
            {
                if (t != null)
                    t.Rollback();
                ok = false;

            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }
            return ok;
        }

    }
}
