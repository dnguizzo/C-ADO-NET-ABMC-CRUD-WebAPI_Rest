using BackEnd.Dominio;
using BackEnd.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transporte
{
    public partial class FormCargaCamion : Form
    {
        private InterfaceGestor gestor;
        private Camion oCamion;


        public FormCargaCamion()
        {
        
            InitializeComponent();
            oCamion = new Camion();
            gestor = new Gestor();

        }

        private void CargarTipoCarga()
        {
            cboTipoCarga.DataSource = gestor.GetTipoCargaList();
            cboTipoCarga.DisplayMember = "NombreTipo";
            cboTipoCarga.ValueMember = "IdTipo";
        }

        private void NroCamion()
        {
            int next = gestor.GetNroProximoCamion();
            if(next != 0)
            {
                txtCamion.Text = next.ToString();
            }
            else
            {
                MessageBox.Show("No se puede obtener el numero del proximo camion","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarCamion()
        {
            oCamion.IdCamion= Convert.ToInt32(txtCamion.Text.ToString());
            oCamion.PesoMax= Convert.ToDouble(txtPesoMax.Text.ToString());
            oCamion.Estado= txtEstado.Text.ToString();
            oCamion.Patente= txtPatente.Text.ToString();




            if (gestor.CargarCamion(oCamion) is true)
            {
                MessageBox.Show("El Camion se cargo con éxtio");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se pudo cargar el camion");
                
            }
        }
   
        
        private void FormCargaCamion_Load(object sender, EventArgs e)
        {
            NroCamion();
            CargarTipoCarga();
            txtPatente.Focus();
            txtPatente.Text = string.Empty;
            txtPesoMax.Text = string.Empty;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {



            if (numPeso.Value <= 0)
            {
                MessageBox.Show("debe ingresar el peso de la carga");
                return;
            }

            foreach (DataGridViewRow item in dgvDetalle.Rows)
            {
                if (item.Cells["colnombreTipo"].Value.ToString().Equals(cboTipoCarga.Text))
                {
                    MessageBox.Show("Tipo de carga ya ingresada");
                    return;
                }
            }

            TipoCarga oTipoCarga = (TipoCarga)cboTipoCarga.SelectedItem;
            double peso = (double)numPeso.Value;
            //int idCarga = 0;
            //idCarga++;

            Carga detalle = new Carga(peso, oTipoCarga);
            dgvDetalle.Rows.Add(new object[] { oTipoCarga.IdTipo,oTipoCarga.NombreTipo,peso});
            oCamion.AgregarCarga(detalle);

           



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPatente.Text.Equals(string.Empty))
            {
                MessageBox.Show("debe ingresar la patente");
                return;
            }

            if (txtEstado.Text.Equals(string.Empty))
            {
                MessageBox.Show("debe ingresar el estado");
                return;
            }

            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar algún tipo de carga al camion");
                return;
            }

            if (txtPesoMax.Text.Equals(string.Empty))
            {
                MessageBox.Show("debe ingresar el peso maximo");
                return;
            }

            double pesoMax = Convert.ToDouble(txtPesoMax.Text.ToString());
            double total = oCamion.TotalPesoCargas();
            if (total > pesoMax)
            {
                MessageBox.Show("Carga total superior al peso maximo del CAMION","Reduzca la carga",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtTotalCarga.Text = Convert.ToString(oCamion.TotalPesoCargas());

            GuardarCamion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                oCamion.QuitarCarga(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            }

            oCamion.TotalPesoCargas();

        }
    }
}
