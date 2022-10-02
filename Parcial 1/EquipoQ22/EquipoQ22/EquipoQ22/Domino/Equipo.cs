using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Domino
{
    public class Equipo
    {
        public int EquipoNro { get; set; }

        public string Pais { get; set; }
        public string Tecnico { get; set; }
        
        public DateTime fechaBaja { get; set; }

        public List<Jugador> Detalles { get; set; }

        public Equipo()
        {
            Detalles = new List<Jugador>();
        }

        public void AgregarDetalle(Jugador detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }


     

              
    }
}
