using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.Dominio;

namespace U2_Veterinaria.DAO.Interfaz
{
    public interface IDaoCliente
    {
        List<Tipo> ObtenerTipos();
        bool Crear(Mascota oMascota);
    }
}
