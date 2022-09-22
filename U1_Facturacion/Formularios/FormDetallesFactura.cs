using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U1_Facturacion.Formularios
{
    public partial class FormDetallesFactura : Form
    {
        private int facturaNro; // agrego el atributo nro para poder identificar el detalle a la factura elegida.
        public FormDetallesFactura(int facturaNro)
        {
            InitializeComponent();
            this.facturaNro = facturaNro;
        }

        private void FormDetallesFactura_Load(object sender, EventArgs e)
        {
            //En el título de la ventana agregamos el número de la factura
            this.Text = this.Text + facturaNro.ToString();
            string sp = "SP_CONSULTAR_DETALLES_FACTURAS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", presupuestoNro));
        }
    }
}
