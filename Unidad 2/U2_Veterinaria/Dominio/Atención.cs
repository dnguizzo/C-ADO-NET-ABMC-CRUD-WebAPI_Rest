using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.Dominio
{
    public class Atención
    {  
        public DateTime Fecha { get; set; } 
        public string Descripcion { get; set; }
        public double Importe { get; set; }

        public Atención ( DateTime fecha, string descripcion, double importe)
        {
            Fecha = fecha;
            Descripcion = descripcion;
            Importe = importe;
        }
    }
}
