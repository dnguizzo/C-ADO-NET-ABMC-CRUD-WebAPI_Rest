using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion
{
    internal class DetalleFactura
    {
        private int cantidad;
        private Articulos articulo; // relacion de composicion

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        
        public Articulos Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }

        public DetalleFactura(int cantidad, Articulos articulo)
        {
            this.cantidad = cantidad;
            this.articulo = articulo;
            
        }

        public double CalcularSubTotalDF() // determiano el subtotal por cada lista del detalle de la factura
        {
            return Articulo.Precio_Unitario * Cantidad;
        }
        public override string ToString()
        {
            return " - Articulo" + articulo.ToString() + " - Cantidad: " + cantidad ;
        }

    }
}
