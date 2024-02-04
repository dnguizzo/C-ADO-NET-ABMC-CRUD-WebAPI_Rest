
using EquipoQ22.datos;
using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EquipoQ22.Datos
{
    class HelperDB
    {

        private SqlConnection cnn;

        public HelperDB() // constructor
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);

        }


        
        public DataTable Consultar_SP(string SPNombre) // Tiene como parámetros el nombre del SP solo para consulta sin parametros
        {

            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();

            cnn.Open();
            // ejecuta el metodo de comandos:
            cmd.Connection = cnn;
            cmd.CommandText = SPNombre;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }

        public DataTable Consultar_SQL(string SPNombre, List<Parametro> values) // Consulta con parametros de entrada
        {
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();

            cnn.Open();
            // ejecuta el metodo de comandos:
            cmd.Connection = cnn;
            cmd.CommandText = SPNombre;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // modelo para agregar los atributos del listado de parametros a mi comando :
            foreach (Parametro oParametro in values)
            {
                cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
            }
            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }

        public int Ejecutar_SQL(string SPNombre, List<Parametro> values) // Script que no devuelve filas, para insertar, modificar o eliminiar con parametros de entrada, de salida y transaccion.
        {
            int filasAfectadas = 0;
            SqlTransaction trans = null; // creo una variable que representa las transacciones y la inicializo.

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();

                trans = cnn.BeginTransaction(); // inicio de las transacciones.
                // ejecuta el metodo de comandos:
                cmd.Connection = cnn;
                cmd.CommandText = SPNombre;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = trans; // agrego el parametro transaccion a la clase SQLcomand y que no está en el metodo configurarcomando.

                if (values != null) // si tiene parametros de entrada
                {
                    foreach (Parametro oParametro in values)
                    {
                        cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor); // modelo para agregar los atributos del listado de parametros a mi comando 
                    }
                }

                filasAfectadas = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException) // en caso de error muestra el mismo
            {
                if (trans != null)
                {
                    trans.Rollback();
                }

            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return filasAfectadas;
        }



       
        public bool ConfirmarEquipo(Equipo oequipo)
        {
            bool respuesta = true;
            SqlTransaction trans = null;

            try
            {
                cnn.Open();
                trans = cnn.BeginTransaction();
                // Insert del maestro
                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_EQUIPO", cnn, trans);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                // Parametros de entrada
                //cmdMaestro.Parameters.AddWithValue("fecha", ofactura.Fecha);
                cmdMaestro.Parameters.AddWithValue("pais",oequipo.Pais);
                cmdMaestro.Parameters.AddWithValue("director_tecnico",oequipo.Tecnico); // referencio a la property
                // Parametros de salida como el iD
                SqlParameter pOut = new SqlParameter("@id", SqlDbType.Int);
                pOut.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(pOut);
                cmdMaestro.ExecuteNonQuery();
                int id_equipo = Convert.ToInt32(pOut.Value);


                // Insert del Detalle
               // int detalleNro = 1; // Inicializo una variable que me cuenta el id del detalle.
                SqlCommand cmdDetalle;

                foreach (Jugador item in oequipo.DetallesEquipo) // contamos la cantidad de elementos del objeto list (detalle) de la factura objeto.
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES_EQUIPO", cnn, trans);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.Clear();
                    cmdDetalle.Parameters.AddWithValue("@id_equipo", id_equipo);
                    cmdDetalle.Parameters.AddWithValue("@id_persona", item.Persona.IdPersona);
                    cmdDetalle.Parameters.AddWithValue("@camiseta", item.Camiseta);
                    cmdDetalle.Parameters.AddWithValue("@posicion", item.Posicion);


                    cmdDetalle.ExecuteNonQuery();

                    //detalleNro++;
                }
                trans.Commit();
            }
            catch (Exception)
            {

                if (trans != null)

                    trans.Rollback();
                respuesta = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return respuesta;
        }
    }
}