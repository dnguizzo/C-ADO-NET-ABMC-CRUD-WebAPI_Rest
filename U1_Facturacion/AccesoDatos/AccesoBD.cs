using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion

{
    internal class AccesoBD
    {
        private SqlConnection conexion = new SqlConnection(Properties.Resources.cadenaConexion);
        private SqlCommand comando = new SqlCommand();

        private void ConfigurarComando_SP(string SPNombre)
        {
            comando.Connection = conexion;
            comando.CommandText = SPNombre;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public DataTable Consultar_SP(string SPNombre) // Tiene como parámetros el nombre del SP
        {
            DataTable tabla = new DataTable();

            conexion.Open();
            ConfigurarComando_SP(SPNombre);
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        public int proximaFactura(string SPNombre) // Ejecuto un SP que solo me devuelve un parametro de salida.
        {
            conexion.Open();
            ConfigurarComando_SP(SPNombre);
            SqlParameter parametroS = new SqlParameter();
            parametroS.ParameterName = "@next";
            parametroS.DbType = DbType.Int32;
            parametroS.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametroS);
            comando.ExecuteNonQuery();

            conexion.Close();
            return Convert.ToInt32(parametroS.Value);

        }

        public bool ConfirmarFactura(Factura ofactura)
        {
            bool respuesta = true;
            SqlTransaction transaccion = null;

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                // Insert del maestro
                SqlCommand cmdMaestro = new SqlCommand("SP_insertar_factura", conexion, transaccion); 
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                // Parametros de entrada
                cmdMaestro.Parameters.AddWithValue("fecha", ofactura.Fecha);
                cmdMaestro.Parameters.AddWithValue("id_Tipopago", ofactura.FormaPago.Id_TipoPago);
                cmdMaestro.Parameters.AddWithValue("cliente", ofactura.Cliente);
                
                // Parametros de salida como el iD
                SqlParameter param = new SqlParameter("@new_id_factura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();
                int id_factura = Convert.ToInt32(param.Value);


                // INsert del Detalle
                int detalleNro = 1; // Inicializo una variable que me cuenta el id del detalle.
                SqlCommand comandoDetalle;
                
            
                for (int i = 0; i < ofactura.DetallesFactura.Count; i++) // contamos la cantidad de elementos del objeto list (detalle) de la factura objeto.
                {
                    comandoDetalle = new SqlCommand("SP_insertar_DetalleFacturas", conexion, transaccion);
                    comandoDetalle.CommandType = CommandType.StoredProcedure;
                    comandoDetalle.Parameters.Clear();
                    comandoDetalle.Parameters.AddWithValue("@id_detalleFactura", detalleNro);
                    comandoDetalle.Parameters.AddWithValue("@id_nro_articulo", ofactura.DetallesFactura[i].Articulo.Id_Articulo);
                    comandoDetalle.Parameters.AddWithValue("@cantidad", ofactura.DetallesFactura[i].Cantidad);
                    comandoDetalle.Parameters.AddWithValue("@id_nro_factura", id_factura);
                    comandoDetalle.ExecuteNonQuery();
                }
                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                respuesta = false;
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return respuesta;
        }

            
        }

        //public bool EliminarCarrera(int id_carrera)
        //{
        //    conexion.Open();
        //    comando = new SqlCommand("sp_registrar_baja_carrera", conexion);
        //    comando.Parameters.AddWithValue("@id_carrera", id_carrera);
        //    int filas = comando.ExecuteNonQuery();
        //    conexion.Close();

        //    return filas == 1;

        //}
    }
}
