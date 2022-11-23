using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.Dominio;

namespace U2_Veterinaria.DAO.Interfaz
{
    public interface IDaoMascota
    {
        List<Tipo> ObtenerTipos();
        bool Crear(Mascota oMascota);
        List<Cliente> ObtenerClientes();
    }
}
