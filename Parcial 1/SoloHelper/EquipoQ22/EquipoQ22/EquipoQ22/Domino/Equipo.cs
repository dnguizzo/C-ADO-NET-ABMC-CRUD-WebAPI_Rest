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

        public List<Jugador> DetallesEquipo { get; set; }

        public Equipo()
        {
            DetallesEquipo = new List<Jugador>();
        }

        public void AgregarDetalle(Jugador detalle)
        {
            DetallesEquipo.Add(detalle);
        }

        public void EliminarDetalle(int indice)
        {
            DetallesEquipo.RemoveAt(indice);
        }

        public int CalcularTotalEquipo()
        {
            
            return DetallesEquipo.Count();
        }


    }
}
