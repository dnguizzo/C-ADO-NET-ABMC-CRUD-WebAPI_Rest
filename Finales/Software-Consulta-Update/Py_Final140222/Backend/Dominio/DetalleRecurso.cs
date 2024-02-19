using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.dominio
{
    class DetalleRecurso

    {
        public Empleado Empleado { get; set; }
        public int ProyectoId { get; set; }
        public String Rol { get; set; }
        public int HrsSemana { get; set; }

        public DetalleRecurso(Empleado oEmpleado, int idPoryecto,string rol, int horas)
        { 
            this.Empleado = oEmpleado;
            this.ProyectoId = idPoryecto;
            this.Rol = rol;
            this.HrsSemana = horas;
            
        }

        public override string ToString()
        {
            return ProyectoId.ToString();
        }


    }
}


