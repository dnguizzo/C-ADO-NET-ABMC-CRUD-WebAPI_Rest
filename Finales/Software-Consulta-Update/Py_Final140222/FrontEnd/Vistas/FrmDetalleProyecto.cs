using Py_Final140222.Backend;
using Py_Final140222.Backend.dominio;
using Py_Final140222.Backend.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Py_Final140222.FrontEnd.Vistas
{
    public partial class FrmDetalleProyecto : Form
    {
        private IApp gestor;
        private int ProyectoNro;
        public FrmDetalleProyecto(int id)
        {
            InitializeComponent();
            gestor = new ServiceApp();
            this.ProyectoNro = id;
                       
        }

        private void FrmProyecto_Load(object sender, EventArgs e)
        {

            lblNroProyecto.Text = ProyectoNro.ToString();
            Proyecto oProyecto = gestor.ConsultarProyectoPorID(ProyectoNro);

            dgvDetalles.DataSource = oProyecto.ToString();

        }
    }
}
