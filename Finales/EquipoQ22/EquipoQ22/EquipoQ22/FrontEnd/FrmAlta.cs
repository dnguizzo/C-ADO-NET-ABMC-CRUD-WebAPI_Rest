
using EquipoQ22.BackEnd.Datos;
using EquipoQ22.BackEnd.Dominio;
using EquipoQ22.BackEnd.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;



namespace EquipoQ22
{
    public partial class FrmAlta : Form
    {
        private InterfaceGestor negocio;
        private Equipo oEquipo;
        public FrmAlta()
        {
            InitializeComponent();
            negocio = new GestorImp();
            oEquipo = new Equipo();
        
        }
        private void FrmAlta_Load(object sender, EventArgs e)
        {
            txtPais.Text = "";
            txtDT.Text = "";
            this.ActiveControl = cboPersona; // Set foco al combo
            GetJugadores();
        }
        private void GetJugadores()
        {
            cboPersona.DataSource = negocio.CargarJugadores(); 
            cboPersona.DisplayMember = "NombreCompleto"; // completa con las propiedades.
            cboPersona.ValueMember = "Id";

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
                MessageBox.Show("Debe seleccionar un PERSONA!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["jugador"].Value.ToString().Equals(cboPersona.Text))
                {
                    MessageBox.Show("La persona seleccionada" + cboPersona.Text + " ya está en el equipo!","Revisar", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    cboPersona.Focus();
                    return;
                }
            }

            if (numCamiseta.Value.Equals(String.Empty))
            {
                MessageBox.Show("Debe asignar un numero de camiseta!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (numCamiseta.Value < 1 || numCamiseta.Value > 23 )
            {
                MessageBox.Show("Debe asignar un numero de camiseta entre 1 y 23 inclusive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            Persona oPersona = (Persona)cboPersona.SelectedItem;
            string posicion = cboPosicion.SelectedItem.ToString();
            int camiseta = (int)numCamiseta.Value;

            Jugador detalle = new Jugador(oPersona,posicion,camiseta);
            oEquipo.AgregarJuagador(detalle);
            dgvDetalles.Rows.Add(new object[] {oPersona.Id, oPersona.NombreCompleto,camiseta,posicion});


            TotalJugadores();

        }

        public int TotalJugadores()
        {
            int total = 0;
            total = oEquipo.TotalJugadores();
            lblTotal.Text = "Total de Jugadores: " + total;
            return total;
        }

        private void GuardarEquipo()
        {
            oEquipo.Pais = txtPais.Text;    
            oEquipo.Director = txtDT.Text;

            if (negocio.CrearEquipo(oEquipo) is true)
            {
                MessageBox.Show("Se registro el equipo de manera exitosa","Registrado",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCampos();
                this.Dispose();
            }
       else
            {
                MessageBox.Show("No se pudo registrar el equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        


        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            if (dgvDetalles.Rows == null)
            {
                MessageBox.Show("Debe ingresar algún jugador");
                    return;
            }
            GuardarEquipo();
        }

        private void LimpiarCampos()
        {
            txtPais.Text = "";
            txtDT.Text = "";
            this.ActiveControl = cboPersona; // Set foco al combo
            GetJugadores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                oEquipo.QuitarJuagador(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                TotalJugadores();
            }
        }
    }
}
