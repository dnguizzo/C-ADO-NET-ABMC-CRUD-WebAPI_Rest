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
    public partial class FormNuevaFactura : Form
    {

        Factura factura1;
        AccesoBD accesoBD;
        public FormNuevaFactura()
        {
            InitializeComponent();
             accesoBD = new AccesoBD();
             factura1 = new Factura(); // contructor por defecto sin parámetros.
             //formapago1 = new Formapago(); // contructor por defecto sin parámetros.

        }

        private void CargarFormaPago()
        {
            DataTable table = accesoBD.Consultar_SP("SP_consultar_formaPago");
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
            nroFactura(); // Muestra el numero de la nueva factura
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

            foreach (DataGridViewRow row in dgvDetalles.Rows) // cargo en mi objeto data los valores de dgv
            {
                if (row.Cells["colArticulo"].Value.ToString().Equals(cboArticulo.Text))
                {
                    MessageBox.Show("ARTICULO: " + cboArticulo.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }

            DataRowView item = (DataRowView)cboArticulo.SelectedItem; // creo un objeto datarow con todos los datos del objeto articulo considerado como una fila u arreglo
            // asigno los valores del arreglo a las variables que luego utilizo para completar el dgv.
            int art = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            Articulos oArticulo = new Articulos(art, nom, pre); // creo un objeto articulo
            int cantidad = Convert.ToInt32(numCantidad.Value);
           

            // 1° Creo un objeto detalle y asigno los valores de los atributos que son la cantidad y un articulo completo, luego agrego el detalle a la factura  y finalmente cargo al datagridview
            DetalleFactura detalle = new DetalleFactura(cantidad, oArticulo);
            factura1.AgregarDetalle(detalle); // agrego el detalle a la factura
            // cargo los datos al dgv:
            dgvDetalles.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], item.Row.ItemArray[2], numCantidad.Value });
            
            CalcularTotal();

        }

        private void CalcularTotal()
        {
            double total = factura1.CalcularTotalFactura(); // tomo el valor calculado en factura
            txtTotal.Text = total.ToString(); // convierto a string

            txtTotal.Text = (total).ToString();
        }

        private void nroFactura()
        {
            int next = 0;
            next = accesoBD.proximaFactura("sp_proxima_factura");
            if (next > 0)
                lblFactura.Text = "Factura Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de Factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4) // Permite eliminar un item del detalle seleccionado
            {
                factura1.EliminarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
              
                CalcularTotal(); // calcula de nuevo el total de la factura.

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void Guardar()
        {
            // Asgino los Datos a la factura para su posterior confirmacion:

            // Creo un objeto forma dep ago y cargo el tipo de pago a la factura
            DataRowView itemf = (DataRowView)cboFormaPago.SelectedItem; // creo un objeto datarow con todos los datos del objeto articulo considerado como una fila u arreglo
            int nrof = Convert.ToInt32(itemf.Row.ItemArray[0]);
            string nomf = itemf.Row.ItemArray[1].ToString();
            Formapago formapago1 = new Formapago(nrof, nomf);
            factura1.FormaPago.Id_TipoPago = Convert.ToInt32(cboFormaPago.SelectedValue); // llamo a las properties
            factura1.Cliente = txtCliente.Text;
            factura1.Fecha = (DateTime)dtpFecha.Value;
            
            

            if (accesoBD.ConfirmarFactura(factura1)) // ejecuto el metodo confirmar del helper y si es verdadero 
            {
                MessageBox.Show("Factura registrada!", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente", "control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (dgvDetalles.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar al menos el detalle", "control", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

            Guardar(); // guarda la factura cargada con us detalle.
        }
    }
}
