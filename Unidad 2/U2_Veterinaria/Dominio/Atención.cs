using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.Dominio
{
    public class Atención
    {   public int Id_atencion { get; set; }
        public DateTime Fecha { get; set; } 
        public string Descripcion { get; set; }
        public double Importe { get; set; }

        public Atención (int id_atencion, DateTime fecha, string descripcion, double importe)
        {
            Id_atencion = id_atencion; 
            Fecha = fecha;
            Descripcion = descripcion;
            Importe = importe;
        }
    }
}
