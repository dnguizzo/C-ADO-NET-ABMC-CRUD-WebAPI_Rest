using EquipoQ22.Datos;
using EquipoQ22.Domino;
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

//COMPLETAR --> Curso: 1w3     Legajo: 113196        Apellido y Nombre: DIEGO GUIZZO

//CadenaDeConexion: "Data Source=sqlgabineteinformatico.frc.utn.edu.ar;Initial Catalog=Qatar2022;User ID=alumnoprog22;Password=SQL+Alu22"

namespace EquipoQ22
{
    public partial class FrmAlta : Form
    {
        Equipo equipo;
        HelperDB accesoBD;

        
        public FrmAlta()
        {
            InitializeComponent();
            accesoBD = new HelperDB();
            equipo = new Equipo(); // contructor por defecto sin parámetros.
                                      //formapago1 = new Formapago(); // contructor por defecto sin parámetros.
            
        }

        private void CargarPersonas()
        {
            DataTable table = accesoBD.Consultar_SP("SP_CONSULTAR_PERSONAS");
            if (table != null)
            {
                cboPersona.DataSource = table;
                cboPersona.DisplayMember = "nombre_completo";
                cboPersona.ValueMember = "id_persona";
            }
        }
        private void FrmAlta_Load(object sender, EventArgs e)
        {
          
            CargarPersonas();
            txtPais.Text = string.Empty;
            txtDT.Text = string.Empty;
            cboPersona.Focus();

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

            if (cboPersona.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar una PERSONA!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (nudCamiseta.Value < 1 && nudCamiseta.Value > 23)
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


                        

            DataRowView item = (DataRowView)cboPersona.SelectedItem; // creo un objeto datarow con todos los datos del objeto articulo considerado como una fila u arreglo
            // asigno los valores del arreglo a las variables que luego utilizo para completar el dgv.
            int per = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            int cla = Convert.ToInt32(item.Row.ItemArray[2]);
            Persona oPersona = new Persona(per, nom, cla); // creo un objeto articulo
            int camiseta = Convert.ToInt32(nudCamiseta.Value);
            string posicion = (cboPosicion.SelectedText).ToString();

            if (!existe(cboPersona.Text)) // preguntamos si no exsite , si no es verdadero.
            {
                // 1° Creo un objeto detalle y asigno los valores de los atributos que son la cantidad y un articulo completo, luego agrego el detalle a la factura  y finalmente cargo al datagridview
                Jugador detalle = new Jugador(oPersona, camiseta, posicion);
                equipo.AgregarDetalle(detalle); // agrego el detalle a la factura
                                                // cargo los datos al dgv:
                dgvDetalles.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], nudCamiseta.Value, cboPosicion.SelectedItem });
            }
            else
            {
                MessageBox.Show("Posicion ya ocupada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularTotal();

            if (equipo.CalcularTotalEquipo() < 1)
            {
                MessageBox.Show("Debe ingresar un jugador al equipo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CalcularTotal()
        {
            double total = equipo.CalcularTotalEquipo(); // tomo el valor calculado en factura
            lblTotal.Text = "Total de jugadores" + total.ToString(); // convierto a string

            
        }


        private void GuardarEquipo()
        {
            accesoBD.ConfirmarEquipo(equipo);

            if (accesoBD.ConfirmarEquipo(equipo)) // ejecuto el metodo confirmar del helper y si es verdadero 
            {
                MessageBox.Show("Equipo registrado!", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Dispose();
                
            }
            else
            {
                MessageBox.Show("No se pudo registrar el equipo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            
            equipo.Pais = txtPais.Text;
            equipo.Tecnico = txtDT.Text;
            

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
                equipo.EliminarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                CalcularTotal(); // calcula de nuevo el total de la factura.

            }
        }
    }
}
