using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Recetas.dominio
{
    public class Ingrediente
    {
        public int IngredienteId { get; set; }
        public string Nombre { get; set; }
        public double Unidad { get; set; }

        public bool Activo { get; set; }


        public Ingrediente(int nro, string nom, double und)
        {
            IngredienteId = nro;
            Nombre = nom;
            Unidad = und;
            
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
