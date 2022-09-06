using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion
{
    internal class Articulos
    {
        private int id_articulo;
        private string nombre;
        private double precio_unitario;

        public int Id_Articulo
        {
            get { return id_articulo; }
            set { id_articulo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Precio_Unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }

        public Articulos (int nro, string nom, double pre)
        {
            this.id_articulo = nro;
            this.nombre = nom;
            this.precio_unitario = pre;
            
        }
        public override string ToString()
        {
            return "Nombre de Articulo: " + Nombre;
        }
    }
}
