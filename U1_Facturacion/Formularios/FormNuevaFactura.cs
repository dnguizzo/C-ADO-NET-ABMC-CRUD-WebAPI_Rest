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
    public partial class Form_Nueva_Factura : Form
    {

        Factura factura;
        AccesoBD accesoBD;
        public Form_Nueva_Factura()
        {
            InitializeComponent();
             accesoBD = new AccesoBD();
             factura = new Factura(); // contructor por defecto sin parámetros.
        }

        private void CargarFormaPago()
        {
            DataTable table = accesoBD.Consultar_SP("SP_consultar_formaPagos");
            if (table != null)
            {
                cboFormaPago.DataSource = table;
                cboFormaPago.DisplayMember = "nombre";
                cboFormaPago.ValueMember = "id_Tipopago";
            }
        }

        private void CargarArticulos()
        {
            DataTable table = accesoBD.Consultar_SP("SP_consultar_articulos");
            if (table != null)
            {
                cboArticulo.DataSource = table;
                cboArticulo.DisplayMember = "nombre";
                cboArticulo.ValueMember = "id_nro_articulo";
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form_Nueva_Factura_Load(object sender, EventArgs e)
        {

            CargarFormaPago();
            CargarArticulos();
            dtpFecha.Value = DateTime.Now;
            txtCliente.Text = string.Empty;
            cboArticulo.Focus();

        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (cboArticulo.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un ARTICULO!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (numCantidad.Value == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colArticulo"].Value.ToString().Equals(cboArticulo.Text))
                {
                    MessageBox.Show("ARTICULO: " + cboArticulo.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }

            DataRowView item = (DataRowView)cboArticulo.SelectedItem;

            int art = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            Articulos oArticulo = new Articulos(art, nom, pre);
            int cantidad = Convert.ToInt32(numCantidad.Value);

            // Creo un objeto detalle y asigno los valoes de sus atributos y luego cargo al datagridview
            DetalleFactura detalle = new DetalleFactura(cantidad, oArticulo);
            factura.AgregarDetalle(detalle); // agrego el detalle a la factura
            dgvDetalles.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], item.Row.ItemArray[2], numCantidad.Value });

            CalcularTotal();

        }

        private void CalcularTotal()
        {
            double total = factura.CalcularTotalFactura(); // tomo el valor calculado en factura
            txtTotal.Text = total.ToString(); // convierto a string

            txtTotal.Text = (total).ToString();
        }

        private void nroFactura()
        {
            int next = accesoBD.proximaFactura();
            if (next > 0)
                lblFactura.Text = "Factura Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de Factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
