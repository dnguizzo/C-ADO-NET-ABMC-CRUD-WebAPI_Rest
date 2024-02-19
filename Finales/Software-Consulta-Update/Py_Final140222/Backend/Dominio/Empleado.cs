using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Py_Final140222.Backend.dominio
{
    class Empleado

    {
        public int EmpleadoId { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int DNI { get; set; }

        public Empleado(int empleadoId, string nombre, string apellido, int dNI)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dNI;
        }

        public override string ToString()
        {
            return ("El empleado es: "+ Nombre + "/" + Apellido);
        }
    }
}


