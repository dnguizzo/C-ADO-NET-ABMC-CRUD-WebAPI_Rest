using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.Dominio
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public List<Mascota> Mascotas { get; set; }

        public Cliente()
        {
            Mascotas = new List<Mascota>();
        }
        public void AgregarDetalle(Mascota mascotas)
        {
            Mascotas.Add(mascotas);
        }
        public void QuitarDetalle(int posicion)
        {
            Mascotas.RemoveAt(posicion);
        }

        public double TotalMascotas()
        {
            double total = 0;
            total = Mascotas.Count();
            return total;
        }
    }
}
