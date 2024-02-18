using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Dominio
{
      public class Carga
    {
        //public int IdCarga { get; set; }
        public double Peso {  get; set; }

        public TipoCarga Tipo;
        
        public Carga(double peso, TipoCarga oTipoCarga) { 
        
            Tipo = oTipoCarga;
            
            Peso = peso;

        }

        public override string ToString()
        {
            return Tipo.NombreTipo;
        }
    }
}
