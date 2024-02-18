using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Dominio
{
    public class TipoCarga
    {
         public int IdTipo { get; set; }    
         public string NombreTipo {  get; set; }
        public TipoCarga(int id,string nombre) {
        
            this.IdTipo = id;
            this.NombreTipo = nombre;

        }

        public override string ToString()
        {
            return NombreTipo;
        }
    }
}
