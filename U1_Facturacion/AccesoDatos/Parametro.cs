using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion

{
    class Parametro
    {
        public Parametro(string clave, Object valor)
        {
            Clave = clave;
            Valor = valor;
        }
        public string Clave { get; set; }
        public Object Valor { get; set; }
    }
}
