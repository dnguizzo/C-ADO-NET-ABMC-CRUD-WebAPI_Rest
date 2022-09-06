using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion
{
    internal class Factura
    {
        private int id_factura;
        private DateTime fecha; 
        private string cliente;
        private FormaPago formaPago = new FormaPago();
        private List<DetalleFactura> detallesFactura = new List<DetalleFactura>(); // se establece la relacion Agregacion con el detallae como uina arreglo o lista por cada id.

        public int Id_Factura
        {
            get { return id_factura; } // no puedo alterar el número, solo puedo buscarlo.
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Formapago FormaPago
        {
            get { return formaPago ; }
            set { formaPago = value; }
        }

        public List<DetalleFactura> DetallesFactura
        {
            get { return detallesFactura; }
            set { detallesFactura = value; }
        }

        public override string ToString()
        {
            return "Dato de Factura: " + cliente;
        }

        public void AgregarDetalle(DetalleFactura detalle)
        {
            detallesFactura.Add(detalle); // metodos propíos de una LIST (coleccion)
        }

        public void EliminarDetalle(int id)
        {
            detallesFactura.RemoveAt(id);
        }

        public double CalcularTotalFactura()
        {
            double total = 0;
            foreach (DetalleFactura item in DetallesFactura) // recorro y sumo cada item del detalle cargado, es decir cada fila de dgv.
                total += item.CalcularSubTotalDF();
            return total;
        }
    }
}
