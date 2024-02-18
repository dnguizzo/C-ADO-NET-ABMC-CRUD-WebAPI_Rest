using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Dominio
{
    public class Camion
    {
       public int IdCamion {  get; set; } 
       public string Patente { get; set; }
       public string Estado { get; set; }
       public double PesoMax {  get; set; }

       public List<Carga> detalle;

       public Camion() { 
        
        detalle = new List<Carga>();

        }

        public void AgregarCarga(Carga oCarga)
        {
            detalle.Add(oCarga);
        }

        public void QuitarCarga(int indice) {
            
            detalle.RemoveAt(indice);}
        public int TotalCargas()
        {
            return detalle.Count;
        }

        public double TotalPesoCargas()
        {
            double pesototal = 0;

            foreach (Carga item in detalle)
            {
                pesototal += item.Peso;
            }
            return pesototal;
        }

    }
}
