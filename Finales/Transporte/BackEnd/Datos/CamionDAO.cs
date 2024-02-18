using BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos
{
    public class CamionDAO : InterfaceDAO
    {
         public List<TipoCarga> GetTipoCargaList()
        { 
            List<TipoCarga> lst = new List<TipoCarga>();
            string sp = "sp_cargar_tipos";

            DataTable dt = HelperDB.ObtenerInstancia.GetSQL(sp, null);

            
            foreach (DataRow item in dt.Rows)
            {
                
                int id = (int)item["idTipo"];
                string nombre = (string)item["nombreTipo"].ToString();
                
                TipoCarga oTipoCarga = new TipoCarga(id,nombre);
                
                lst.Add(oTipoCarga);
            }
            
            return lst;
        }
        public bool CargarCamion(Camion oCamion)
        {
            bool result = HelperDB.ObtenerInstancia().InsertSQL("SP_INSERTAR_CAMION", "SP_INSERTAR_DETALLE", oCamion);
            return result;
        }

    }
}
