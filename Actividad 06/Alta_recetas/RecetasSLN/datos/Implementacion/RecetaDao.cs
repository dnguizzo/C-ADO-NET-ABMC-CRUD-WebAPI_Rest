using Alta_Recetas.datos.Interfaz;
using Alta_Recetas.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Recetas.datos.Implementacion
{
    public class RecetaDao : IDaoReceta
    {
        public int ObtenerProximoNro()
        {
            string sp = "SP_PROXIMO_ID";
            return HelperDB.ObtenerInstancia().ConsultaEscalarSQL(sp, "@next");
        }

        public List<Ingrediente> ObtenerIngrediente()
        {
            List<Ingrediente> lst = new List<Ingrediente>();
            
            string sp = "SP_CONSULTAR_PRODUCTOS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach(DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["id_producto"].ToString());
                string nombre = dr["n_producto"].ToString();
                double precio = double.Parse(dr["precio"].ToString());
                bool activo = dr["activo"].ToString().Equals("S");

                Ingrediente aux = new Ingrediente(nro, nombre, precio);
                aux.Activo = activo;
                lst.Add(aux);
                    
            }

            return lst;
        }
    }
}
