using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using U2_Veterinaria.Dominio;
using U2_Veterinaria.Factory.Implementación;
using U2_Veterinaria.Factory.Interfaz;

namespace U2_Veterinaria
{
    public partial class FormAltaMascota : Form
    {
        private IServicio oServicio;
        private Mascota nuevaMascota;

        public FormAltaMascota()
        {
            InitializeComponent();
            oServicio = new ServicioVeterinaria();
            nuevaMascota = new Mascota();
        }

        private void FormAltaMascota_Load(object sender, EventArgs e)
        {
            
            txtDescripcion.Text = string.Empty;
            dTFecha.Value = DateTime.Now;
            CargarClientes();
            CargarTipos();
            cboTipo.Focus();
        }

        private void CargarClientes()
        {
            cboTipo.DataSource = oServicio.ObtenerClientes();
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Codigo";
        }

        private void CargarTipos()
        {
            cboTipo.DataSource = oServicio.ObtenerTipos();
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Id_Tipo";
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            if (cboTipo != null)
            {
                MessageBox.Show("Debe seleccionar un tipo de mascota", "Control");
                return;
            }

            if (int.Parse(txtImporte.Text) < 10000)
            {
                MessageBox.Show("Requiere cuenta corriente");
            }

            foreach (DataGridViewRow row in dgvAtencion.Rows)
            { 
            if (row.Cells["descripcion"].Value.ToString().Equals(txtDescripcion.Text))
                {
                    MessageBox.Show("descripcion: " + txtDescripcion.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                        
            }


            
            DateTime fecha = dTFecha.Value;
            string descr = txtDescripcion.ToString();
            double import = int.Parse(txtImporte.Text.ToString());
            Atención DetalleAtencion = new Atención( fecha, descr, import);
            nuevaMascota.AgregarDetalle(DetalleAtencion);
            dgvAtencion.Rows.Add(new object[] {fecha, descr, import });

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = nuevaMascota.TotalAtenciones();
            txtTotal.Text = total.ToString();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvAtencion.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos una atención veterinaria!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Guardar();
        }

        private void Guardar()
        {
            //datos de la Mascota:


            nuevaMascota.Nombre = txtNombre.Text.ToString();
            nuevaMascota.Edad = Convert.ToInt32(txtEdad.Text.ToString());
            nuevaMascota.Tipo = (Tipo)cboTipo.SelectedItem;
            nuevaMascota.Cliente = (Cliente)cboCliente.SelectedItem;



            if (oServicio.Crear(nuevaMascota))
            {
                MessageBox.Show("Mascota registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAtencion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAtencion.CurrentCell.ColumnIndex == 4)
            {
                nuevaMascota.QuitarDetalle(dgvAtencion.CurrentRow.Index);
                dgvAtencion.Rows.Remove(dgvAtencion.CurrentRow);
                CalcularTotal();


            }
        }
    }
}
