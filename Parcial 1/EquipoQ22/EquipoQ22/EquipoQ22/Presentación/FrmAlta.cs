using EquipoQ22.Domino;
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

        private Equipo nuevo;
        public FrmAlta(FabricaServicio fabrica)
        {
            InitializeComponent();
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
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPais.Text))
            {
                MessageBox.Show("Debe ingresar un pais válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPais.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDT.Text))
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDT.Focus();
                return;
            }

            if (cboPersona.Text.Equals(String.Empty)) // valido en el combo
            {
                MessageBox.Show("Debe seleccionar un PERSONA!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           

            //foreach (DataGridViewRow row in dgvDetalles.Rows) // valido en el dgv que no haya el mismo producto cargado 
            //{
            //    if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
            //    {
            //        MessageBox.Show("PRODUCTO: " + cboProductos.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;

            //    }
            //}



            Persona p = (Persona)cboPersona.SelectedItem;
            Jugador j = (Jugador)cboPosicion.SelectedItem;

       

            DetalleEquipo detalle = new DetalleEquipo(j);
            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { j.p.IdPersona, j.p.NombreCompleto, j.Camiseta, j.Posicion });

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = nuevo.CalcularTotal();
            lblTotal.Text = "Total de Jugadores: " + total.ToString();

            
        }

        private void CargarPersonas()
        {
            cboPersona.DataSource = servicio.ObtenerPersonas(); // carga una list de personas
            cboPersona.DisplayMember = "NombreCompleto"; // Properties del objetos producto.
            cboPersona.ValueMember = "IdPersona";

        }

        //private void CargarPosicion()
        //{
        //    cboPersona.DataSource = servicio.ObtenerPosiciones(); // carga una list de personas
        //    cboPersona.DisplayMember = "NombreCompleto"; // Properties del objetos producto.
        //    cboPersona.ValueMember = "IdPersona";

        //}

        private void GuardarEquipo()
        {
            //datos del equipo:
            nuevo.Pais = txtPais.Text;
            nuevo.Tecnico = txtDT.Text;


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

            GuardarEquipo();
        }

        private void LimpiarCampos()
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }



    }
}
