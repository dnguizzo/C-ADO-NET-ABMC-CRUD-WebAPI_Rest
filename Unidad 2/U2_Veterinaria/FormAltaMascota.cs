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
            
            txtDescricpion.Text = string.Empty;
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


            
            DateTime fecha = dTFecha.Value;
            string descr = txtDescricpion.ToString();
            double import = int.Parse(txtImporte.Text.ToString());
            Atención DetalleAtencion = new Atención(atencion, fecha, descr, import);
            nuevaMascota.AgregarDetalle(DetalleAtencion);
            dgvAtencion.Rows.Add(new object[] {fecha, descr, import });
        }
    }
}
