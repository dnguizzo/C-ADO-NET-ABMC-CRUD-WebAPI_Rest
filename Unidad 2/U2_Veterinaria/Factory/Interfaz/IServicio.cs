using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2_Veterinaria.Dominio;

namespace U2_Veterinaria.Factory.Interfaz
{
    public interface IServicio
    {
        List<Tipo> ObtenerTipos();
        bool Crear(Mascota oMascota);
        List<Cliente> ObtenerClientes();
       
    }
}
