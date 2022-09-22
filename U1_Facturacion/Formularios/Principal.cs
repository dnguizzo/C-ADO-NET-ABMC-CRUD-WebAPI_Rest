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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Facturación", "Unidad 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void consultaFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultaFactura consultaFactura = new FormConsultaFactura();
            consultaFactura.ShowDialog();// muestra el formulario de para consultar facturas
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevaFactura nuevaFactura = new FormNuevaFactura();
                nuevaFactura.ShowDialog();// muestra el formulario de nueva factura
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
