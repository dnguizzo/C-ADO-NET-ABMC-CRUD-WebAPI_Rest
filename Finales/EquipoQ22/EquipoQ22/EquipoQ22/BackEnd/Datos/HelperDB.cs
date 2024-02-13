using EquipoQ22.BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Datos
{
    class HelperDB
    {
        private static HelperDB instance;
        private SqlConnection cnn;

        private HelperDB()
        {

            cnn = new SqlConnection(Properties.Resources.cnnString);

        }

        public static HelperDB ObtenerInstance()
        {

            if (instance == null)
            {
                instance = new HelperDB();

            }
            return instance;
        }

        public SqlConnection RecuperarConexión() {
            return cnn;
        } 
        public DataTable GetSQL(string spNombre, List<Parametro> valores)
        {
            DataTable dt = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = spNombre;
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (valores != null)
            {
                foreach (Parametro item in valores)
                {
                    cmd.Parameters.AddWithValue(item.Clave, item.Value);
                }
            }
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public bool InsertSQL(string spMaestro,string spDetalle, Equipo oEquipo)
        {
            bool resultado = true;
            
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                t = cnn.BeginTransaction();
                cmd.CommandText = spMaestro;
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
                int nroEquipo = (int)pout.Value;

                SqlCommand cmd2;

                foreach (Jugador j in oEquipo.DetalleEquipo)
                {
                    cmd2 = new SqlCommand();
                    cmd2.CommandText = spDetalle;
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
        //public bool Delete_SQL(string spNombre, List<Parametro> valores)
        //{
        //    bool resultado = false;
        //    SqlTransaction t = null;

        //    try
        //    {
        //        cnn.Open();
        //        SqlCommand cmd = new SqlCommand(spNombre, cnn);
        //        t = cnn.BeginTransaction();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Transaction = t;
        //        cmd.Parameters.Clear();
        //        if (valores != null)
        //        {
        //            foreach (Parametro item in valores)
        //            { cmd.Parameters.AddWithValue(item.Clave, item.Value); }

        //        }
        //        if (cmd.ExecuteNonQuery() != 0)
        //        {
        //            resultado = true;
        //        }

        //        t.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (t != null) {  t.Rollback(); }
        //    }


        //    finally
        //    { 
        //    if (cnn != null && cnn.State==ConnectionState.Open) { cnn.Close(); } 
        //    }

        //    return resultado;
        //}


    }
}

    
 
