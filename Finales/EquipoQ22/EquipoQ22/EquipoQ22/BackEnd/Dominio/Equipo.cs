using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.BackEnd.Dominio
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Pais { get; set; }

        public string Director { get; set; }

        public List<Jugador> DetalleEquipo { get; set; }
        public Equipo() {
       this.DetalleEquipo = new List<Jugador>();
            
        }

        public void AgregarJuagador(Jugador oJugador) {
            DetalleEquipo.Add(oJugador);
        }

        public void QuitarJuagador(int indice)
        {
            DetalleEquipo.RemoveAt(indice);
        }

        public int TotalJugadores() {  return DetalleEquipo.Count; }
    }
}
