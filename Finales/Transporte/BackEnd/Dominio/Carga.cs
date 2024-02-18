using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Dominio
{
      public class Carga
    {
         int IdCarga { get; set; }
         public double Peso {  get; set; }

        public TipoCarga Tipo;

        public Carga(TipoCarga oTipoCarga, int id, double peso) { 
        
            Tipo = oTipoCarga;
            IdCarga = id;
            Peso = peso;

        }

        public override string ToString()
        {
            return Tipo.NombreTipo;
        }
    }
}
