using Py_Final140222.Backend.Negocio;
using Py_Final140222.Backend.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Py_Final140222.Backend.dominio;
using Py_Final140222.FrontEnd.Vistas;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Py_Final140222.FrontEnd.Vistas
{
    public partial class FrmConsultaMaestro : Form
    {
        private IApp gestor;

        public FrmConsultaMaestro()
        {
            InitializeComponent();
            gestor = new ServiceApp();
        }

       
        private bool ValidarFechas()
        {
            if (dtp1.Value > dtp2.Value)
            {
                MessageBox.Show("Rango de Fechas no válido");
                return false;
            }
            if(dtp1.Value > DateTime.Today)
            {
                MessageBox.Show("Rango de Fechas no válido");
                return false;
            }

            return true;
        }

        private bool ValidarFechaBaja()
        {
            bool resultado = true;
            if (dataGridView1.CurrentRow.Cells["colfecfin"].Value != null || dataGridView1.CurrentRow.Cells["colfecfin"].Value.ToString() != string.Empty)
            {
               return false;
            }
            
            return resultado;
        }




        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidarFechas() is true)
            {
                dataGridView1.Rows.Clear();
                DateTime desde = dtp1.Value;
                DateTime hasta = dtp2.Value;
                List<Proyecto> lst = gestor.ConsultarProyectosPorFechas(desde,hasta);
                    foreach (Proyecto item in lst)
                    {
                    dataGridView1.Rows.Add(new object[] {
                        item.ProyectoId,
                        item.Nombre,
                        item.fechaInicio.ToString("dd/mm/aaaa"),
                        item.fechaFin.ToString("dd/mm/aaaa") 
                    });
                    
                   
                    }
                                  
              

            }
           

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarFechaBaja() is false)
            {
                MessageBox.Show("El proyecto ya tiene una fecha de cierre");
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DateTime fec_baja = DateTime.Now;

            if (gestor.CerrarProyecto(id,fec_baja))
            {
                MessageBox.Show("El proyecto se cerró correctamente");
                // cargo de nuevo el componente
                dataGridView1.Rows.Clear();
                DateTime desde = dtp1.Value;
                DateTime hasta = dtp2.Value;
                List<Proyecto> lst = gestor.ConsultarProyectosPorFechas(desde, hasta);
                foreach (Proyecto item in lst)
                {
                    dataGridView1.Rows.Add(new object[] {
                        item.ProyectoId,
                        item.Nombre,
                        item.fechaInicio.ToString("dd/mm/aaaa"),
                        item.fechaFin.ToString("dd/mm/aaaa")
                    });
                }
                    // otra opcion es: dataGridView1.DataSource = gestor.ConsultarProyectosPorFechas(dtp1.Value, dtp2.Value);
            }
           
        }

      

        private void FrmConsultarProyecto_Load(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now.AddDays(-7);
            dtp2.Value = DateTime.Now;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dataGridView1.CurrentRow.Cells["colidproyecto"].Value.ToString());
                new FrmDetalleProyecto(nro).ShowDialog();
            }
        }
    }
}
