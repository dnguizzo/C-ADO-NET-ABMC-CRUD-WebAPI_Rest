using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Recetas.dominio
{
    public class DetalleReceta
    {
        public Ingrediente Ingrediente { get; set; }
        public int Cantidad { get; set; }
        public DetalleReceta(Ingrediente i, int cant) {
            Ingrediente = i;
            Cantidad = cant;
        }

        public double CalcularSubTotal() {
            return  Cantidad;
        }

    }
}
