using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.DAO.Interfaz;
using U2_Veterinaria.DAO.Singleton;
using U2_Veterinaria.Dominio;

namespace U2_Veterinaria.DAO.Implementación
{
    public class MascotaDAO : IDaoMascota
    {


        List<Tipo> IDaoMascota.ObtenerTipos()
        {
            List<Tipo> lst = new List<Tipo>();
            string sp = "SP_CONSULTAR_TIPOS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow item in t.Rows)
            {
                int id_tipo = int.Parse(item["id_tipo"].ToString());
                string nombre = item["nombre"].ToString();
                Tipo oTipo = new Tipo(id_tipo, nombre);
                lst.Add(oTipo);
            }
            return lst;
        }

        public bool Crear(Mascota oMascota)
        {
            return HelperDB.ObtenerInstancia().CrearMascotaAtencion("SP_INSERTAR_MASCOTA", "SP_INSERTAR_ATENCION", oMascota);
        }
       
    }
}
