using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos
{
    public class Parametros
    {
         public string Clave {  get; set; }
        public object Valor { get; set; }   

        public Parametros(string clave, object valor) {
        
            this.Clave = clave; 
            this.Valor = valor;

        }
    }
}
