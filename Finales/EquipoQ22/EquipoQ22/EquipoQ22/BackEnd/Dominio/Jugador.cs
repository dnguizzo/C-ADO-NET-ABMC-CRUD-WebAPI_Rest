using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Dominio
{
    public class Jugador
    {
        public Persona Persona ;
        public string Posicion {  get; set; }
        public int Camiseta { get; set; }
        public Jugador(Persona p, string posicion, int camiseta) {
            this.Camiseta = camiseta;
            this.Persona = p;
            this.Posicion = posicion;

                }
        public override string ToString()
        {
            return Persona.NombreCompleto.ToString();
        }
    }
}
