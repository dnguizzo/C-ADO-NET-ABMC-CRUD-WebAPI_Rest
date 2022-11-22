using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.DAO.Singleton
{
    public class Parametro
    {
        public string Clave { get; set; }
        public object Valor { get; set; }

        public Parametro(string clave, object valor)
        {
            this.Clave = clave;
            Valor = valor;
        }
    }
}
