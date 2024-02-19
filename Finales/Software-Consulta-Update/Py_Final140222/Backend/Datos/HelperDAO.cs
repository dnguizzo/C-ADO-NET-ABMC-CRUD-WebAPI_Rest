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
    class HelperDAO
    {
        private static HelperDAO instancia;
        private SqlConnection cnn;

        private HelperDAO()
        { 

            
            cnn= new SqlConnection(Properties.Resources.cnnString);

        }
        public static HelperDAO ObtenerInstancia() 
        {
        
            if (instancia == null)
            {
                instancia = new HelperDAO();
            }

            return instancia;
        
        }

        public DataTable GetSQL(String sp, List<Parametro> param) { 
            
            DataTable dt = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (param != null)
            {
                foreach (Parametro item in param)
                {
                    cmd.Parameters.AddWithValue(item.Clave, item.Valor);
                }
                
            }
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public bool UpdateSQL(string sp, int nro, DateTime fec_baja)
        {
            bool flag = true;
            SqlTransaction t = null;


            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp,cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CERRAR_PROYECTO";
                cmd.Parameters.AddWithValue("@id", nro);
                cmd.Parameters.AddWithValue("@fec_baja", fec_baja );
                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                { t.Rollback(); }
                flag = false;

            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return flag;
        }
    }
}
