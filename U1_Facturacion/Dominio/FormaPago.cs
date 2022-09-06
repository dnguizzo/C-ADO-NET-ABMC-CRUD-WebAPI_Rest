using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Facturacion
{
    internal class Formapago
    {
        private int id_tipoPago;
        private string nombre;
        

        public int Id_TipoPago
        {
            get { return id_tipoPago; }
            set { id_tipoPago = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

      

        public Formapago (int nro, string nom)
        {
            this.id_tipoPago = nro;
            this.nombre = nom;
            
        }
        public override string ToString()
        {
            return "Nombre de Articulo: " + Nombre;
        }
    }
}
