using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Channels;
using BackEnd.Dominio;

namespace BackEnd.Datos
{
    class HelperDB
    {
        private static HelperDB instancia;
        private SqlConnection cnn;

        private HelperDB() { 
        
        cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static HelperDB ObtenerInstancia() {
            if (instancia == null)
            {
                instancia = new HelperDB();
            }
            return instancia; }


        public DataTable GetSQL(string sp, List<Parametros> valores)
        {
            DataTable dt = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sp,cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (valores != null)
            {
                foreach (Parametros item in valores)
                {
                    cmd.Parameters.AddWithValue(item.Clave, item.Valor);
                    }
            }
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public int GetEscalarSQL(string sp)
        {
            int NroCamion = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType= CommandType.StoredProcedure;

            SqlParameter pout = new SqlParameter();
            pout.ParameterName = "@next";
            pout.DbType = DbType.Int32;
            pout.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pout);

            cmd.ExecuteNonQuery();
            NroCamion = (int)pout.Value;
           
            cnn.Close() ;
            return NroCamion;
        }

        public bool InsertSQL(string spMaestro, string spDetalle,Camion oCamion)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(spMaestro, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCamion", oCamion.IdCamion);
                cmd.Parameters.AddWithValue("@patente", oCamion.Patente);
                cmd.Parameters.AddWithValue("@estado", oCamion.Estado);
                cmd.Parameters.AddWithValue("@pesoMax", oCamion.PesoMax);

                //SqlParameter pout = new SqlParameter();
                //pout.ParameterName = "id_camion";
                //pout.DbType = DbType.Int32;
                //pout.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(pout);

                cmd.ExecuteNonQuery();
                //int NroCamion = (int)pout.Value;

                SqlCommand cmd2 = null;
                int idCarga = 1;
                foreach (Carga item in oCamion.detalle)
                {
                    cmd2 = new SqlCommand(spDetalle, cnn, t);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCamion", oCamion.IdCamion);
                    cmd.Parameters.AddWithValue("@@idCarga", idCarga);
                    cmd.Parameters.AddWithValue("@idTipo", item.Tipo.IdTipo);
                    cmd.Parameters.AddWithValue("@peso", item.Peso);
                    cmd2.ExecuteNonQuery();
                    idCarga++;


                }

                t.Commit();


            }

            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }

            finally
            {


                if (t != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
           
            return resultado;

        }
    }
}
