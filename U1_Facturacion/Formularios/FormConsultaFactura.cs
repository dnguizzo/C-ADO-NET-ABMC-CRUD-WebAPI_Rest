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
    public partial class FormConsultaFactura : Form
    {
        AccesoBD gestor;
        public FormConsultaFactura()
        {
            InitializeComponent();
            gestor = new AccesoBD();
        }

        private void FormConsultaFactura_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(30); // metodo que agrega días a la fecha actual.
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacturas.CurrentCell.ColumnIndex == 4) // Permite ver el detalle de una factura seleccionado en la columna 4 Acciones.
            {
                int nro = int.Parse(dgvFacturas.CurrentRow.Cells["colNro"].Value.ToString()); // me devuelve el numero de la factura segúna el nombre de la columna del dgv de lal fila seleccionada.
                // Luego se crea un formulario para mostrar el detalle de la factura seleccionada:
                new FormDetallesFactura(nro).ShowDialog();

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sp = "sp_consultar_facturas";
            List<Parametro> lst = new List<Parametro>(); // Creo un objeto parametro que sea una lista para psar los filtros
            lst.Add(new Parametro("@fecha_desde", dtpDesde.Value)); // agrego los nuvos parametros a mi lista
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value)); // agrego los nuvos parametros a mi lista
            lst.Add(new Parametro("@cliente", txtCliente.Text)); // agrego los nuvos parametros a mi lista

            dgvFacturas.Rows.Clear(); // Limpio mi dgv:
            DataTable dt = gestor.Consultar_SQL(sp,lst); // creo la tabla para guardarl os datos en memoria ejecuando la consulta con parametros
            // cargo los datos al dgv:
            foreach(DataRow fila in dt.Rows) // recorro los datos del datatable
            {
                dgvFacturas.Rows.Add(new object[]  // cargo los datos al dgv
                    {
                    fila["id_nro_factura"].ToString(),
                    fila["fecha"].ToString(),
                    fila["cliente"].ToString(),
                    fila["id_Tipopago"].ToString()
                    });
                
            }

        }
    }
}
