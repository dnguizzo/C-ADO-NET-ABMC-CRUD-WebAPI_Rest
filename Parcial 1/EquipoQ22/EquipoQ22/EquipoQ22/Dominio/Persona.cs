using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Dominio
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public int Clase { get; set; }



        public Persona(int nro, string nom, int clase)
        {
            IdPersona = nro;
            NombreCompleto = nom;
            Clase = clase;
          
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }

    
}
