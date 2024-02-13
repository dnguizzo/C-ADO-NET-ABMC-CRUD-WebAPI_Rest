using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Datos
{
    public class Parametro
    {
        public string Clave { get; set; }
        public object Value { get; set; }

        public Parametro(string clave, object value) {
        
            this.Clave = clave;
            this.Value = value;
        }
    }
}
