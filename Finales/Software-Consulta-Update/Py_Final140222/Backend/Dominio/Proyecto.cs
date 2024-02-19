using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.dominio
{
    class Proyecto
   
    {
        public int ProyectoId { get; set; }
        public String Nombre { get; set; }
        public DateTime fechaInicio{ get; set; }
        public DateTime fechaFin { get; set; }

        public List<DetalleRecurso> Detalles { get; set; }

        public Proyecto() 
        {
            this.Detalles = new List<DetalleRecurso>();
        }

        public void AgregarRecurso(DetalleRecurso oDetalleRecurso)
        {
            Detalles.Add(oDetalleRecurso);
        }

        public void QuitarRecurso(int indice)
        {
            Detalles.RemoveAt(indice);
        }


    }
}


