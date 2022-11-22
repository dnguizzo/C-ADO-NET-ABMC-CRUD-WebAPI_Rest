using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.DAO.Implementación;
using U2_Veterinaria.DAO.Interfaz;
using U2_Veterinaria.Dominio;
using U2_Veterinaria.Factory.Interfaz;

namespace U2_Veterinaria.Factory.Implementación
{
    internal class ServicioVeterinaria : IServicio
    {
        private IDaoMascota dao;

        public ServicioVeterinaria ()
        {
            dao = new MascotaDAO();

        }
        public bool Crear(Mascota oMascota)
        {
           return dao.Crear(oMascota);
        }

        public List<Tipo> ObtenerTipos()
        {
             return dao.ObtenerTipos();
        }
    }
}
