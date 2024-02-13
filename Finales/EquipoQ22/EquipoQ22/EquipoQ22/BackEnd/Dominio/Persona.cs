using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public int Clase { get; set; }


        public Persona(int id, string nombre, int clase) {
        
        this.Id = id;
        this.NombreCompleto = nombre;
        this.Clase = clase;
        }

        public override string ToString() 
        {
            return NombreCompleto;
        }
    }
}
