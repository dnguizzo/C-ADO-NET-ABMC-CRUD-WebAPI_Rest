using EquipoQ22.Dominio;
using EquipoQ22.Servicios;
using EquipoQ22.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//COMPLETAR --> Curso:      Legajo:         Apellido y Nombre:

//CadenaDeConexion: "Data Source=sqlgabineteinformatico.frc.utn.edu.ar;Initial Catalog=Qatar2022;User ID=alumnoprog22;Password=SQL+Alu22"

namespace EquipoQ22
{
    public partial class FrmAlta : Form
    {
        private IServicio servicio;
        private FabricaServicio fabrica;

        private Equipo nuevo;
        public FrmAlta()
        {
            InitializeComponent();
            fabrica = new FabricaServicioImp();
            servicio = fabrica.CrearServicio();

            CargarPersonas();
            //Crear nuevo equipo:
            nuevo = new Equipo();
        }

       
        private void FrmAlta_Load(object sender, EventArgs e)
        {
            txtPais.Text = "";
            txtDT.Text = "";
            this.ActiveControl = cboPersona; // Set foco al combo
        }

        private bool existe(string selectedItem1)
        {
            bool aux = false;
            foreach (DataGridViewRow item in dgvDetalles.Rows)
            {
                if (item.Cells["IdPersona"].Value.ToString().Equals(selectedItem1))
                {
                    aux = true;
                    break;
                }

            }
            return aux;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

          

            if (cboPersona.Text.Equals(String.Empty)) // valido en el combo
            {
                MessageBox.Show("Debe seleccionar un PERSONA!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (nudCamiseta.Value < 1 || nudCamiseta.Value > 23)
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }





            Persona p = (Persona)cboPersona.SelectedItem;
            int camiseta = Convert.ToInt32(nudCamiseta.Value);
            string posicion = (cboPosicion.SelectedText).ToString();

            if (!existe(cboPersona.Text)) // preguntamos si no exsite , si no es verdadero.
            {
                Jugador detalle = new Jugador(p,camiseta,posicion);
            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { p.IdPersona, p.NombreCompleto, nudCamiseta.Value, cboPosicion.SelectedItem });
            }
            else
            {
                MessageBox.Show("Posicion ya asiganda a esa persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularTotal();
            if (nuevo.CalcularTotalEquipo() < 1)
            {
                MessageBox.Show("Debe ingresar un jugador al equipo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CalcularTotal()
        {
            double total = nuevo.CalcularTotalEquipo();
            lblTotal.Text = "Total de Jugadores: " + total.ToString();

            
        }

        private void CargarPersonas()
        {
            cboPersona.DataSource = servicio.ObtenerPersonas(); // carga una list de personas
            cboPersona.DisplayMember = "NombreCompleto"; // Properties del objetos producto.
            cboPersona.ValueMember = "IdPersona";

        }

       

        private void GuardarEquipo()
        {
           


            if (servicio.CrearEquipo(nuevo)) // por defecto lo toma como  verdadero.
            {
                MessageBox.Show("Equipo registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPais.Text == "")
            {
                MessageBox.Show("Debe ingresar un pais!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtDT.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //datos del equipo:
            nuevo.Pais = txtPais.Text;
            nuevo.Tecnico = txtDT.Text;

            GuardarEquipo();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtPais.Text = String.Empty;
            txtDT.Text = String.Empty;
            cboPersona.SelectedIndex = -1;
            cboPosicion.SelectedIndex = -1;
            nudCamiseta.Value = 1;
            dgvDetalles.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4) // Permite eliminar un item del detalle seleccionado
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                CalcularTotal(); // calcula de nuevo el total de la factura.

            }
        }
    }
}
