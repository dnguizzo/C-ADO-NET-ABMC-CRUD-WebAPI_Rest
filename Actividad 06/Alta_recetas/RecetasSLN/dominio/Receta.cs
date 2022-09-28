using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Recetas.dominio
{
    public class Receta
    {
        public int RecetaNro { get; set; }
        
        public string Nombre { get; set; }
        public string Cheff { get; set; }
        public int TipoReceta { get; set; }
        public DateTime fechaBaja { get; set; }

        public List<DetalleReceta> Detalles { get; set; }

        public Receta()
        {
            Detalles = new List<DetalleReceta>();
        }

        public void AgregarDetalle(DetalleReceta detalle) {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice) {
            Detalles.RemoveAt(indice);
        }


        public double CalcularTotal() {
            double total = 0;
            foreach (DetalleReceta item in Detalles)
                total += item.CalcularSubTotal();
            return total;
        }

     
    }
}
