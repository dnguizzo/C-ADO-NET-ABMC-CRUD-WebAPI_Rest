using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.Dominio
{
    public class Tipo
    {
        public int Id_tipo { get; set; }
        public string Nombre { get; set; }

        public Tipo (int id_tipo,string nombre)
        {
           this.Id_tipo = id_tipo;
           this.Nombre = nombre;
        }

        public Tipo()
        {
        }
    }
}
