using EquipoQ22.datos;
using EquipoQ22.Datos;
using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Datos.Implementacion
{
    public class EquiopiDao : IEquipoDao // Herencia mediante interfaz - implementa los metodos de la inerfaz Idao
    {
       
        public List<Persona> ObtenerPersonas()
        {
            List<Persona> lst = new List<Persona>(); // CREO UNA LISTA DE PERSONAS

            string sp = "SP_CONSULTAR_PERSONAS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio MAPING
                int nro = int.Parse(dr["id_persona"].ToString());
                string nombre = dr["nombre_completo"].ToString();
                int clase = int.Parse(dr["clase"].ToString());
                
                Persona aux = new Persona(nro, nombre, clase);
                //aux.Activo = activo;
                lst.Add(aux);

            }

            return lst; // ME DEVULEVE UNA LISTA DE PERSONAS
        }

        public bool Crear(Equipo oEquipo)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion(); // creo conexion porque no es un atributo de la claae y si en el helper
            SqlTransaction t = null; // inicializo la variable
            SqlCommand cmd = new SqlCommand(); // Creo una clase de comandos sin parametros y luego los inicializo.
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction(); // comienzo de la transaccion 
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_EQUIPO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pais", oEquipo.Pais); // Parametros de entrada sigo el orden que tienen en el sp
                cmd.Parameters.AddWithValue("@director_tecnico", oEquipo.Tecnico);
                

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int equipoNro = (int)pOut.Value; // Recupero el valor del parametro de salida y lo guardo en la variable

                SqlCommand cmdDetalle; // creo un nuevo comando para insetar en la tabla de detalles
                
                foreach (Jugador item in oEquipo.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES_EQUIPOS", cnn, t); // creo un comand con parametros ya que ya los tengo creados en la transaccion anterior.
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_equipo", equipoNro); // parametros de entrada sigo el orden del sp.
                    cmdDetalle.Parameters.AddWithValue("@id_persona", item.Persona.IdPersona);
                    cmdDetalle.Parameters.AddWithValue("@camiseta", item.Camiseta); // lo saco del detalle que tiene un producto lista y este una properti coin el valor.
                    cmdDetalle.Parameters.AddWithValue("@posicion", item.Posicion);// atributo del detalle.
                    cmdDetalle.ExecuteNonQuery();

                
                }
                t.Commit();
            }

            catch (Exception)
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

        public bool CrearEquipo(Equipo oEquipo)
        {
            throw new NotImplementedException();
        }
    }
}

