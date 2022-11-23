using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Veterinaria.Dominio
{
    public class Mascota
    {
        public int Id_Mascota { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Tipo Tipo {get; set;}
        public List<Atención> DetalleAtenciones { get; set; }

        public Cliente Cliente { get; set; }

        public Mascota (int id_mascota,string nombre, int edad, Tipo tipo, List<Atención> detalleAtenciones, Cliente cliente)
        {
            Id_Mascota = id_mascota;
            Nombre = nombre;
            Edad = edad;
            Tipo = tipo;
            DetalleAtenciones = detalleAtenciones;
            Cliente = cliente;
        }

        public Mascota()
        {
        DetalleAtenciones = new List<Atención> ();
        }

        public void AgregarDetalle(Atención DetalleAtencion)
        {
            DetalleAtenciones.Add (DetalleAtencion);
        }
        public void QuitarDetalle(int posicion)
        {
            DetalleAtenciones.RemoveAt (posicion);
        }
        public override string ToString()
        {
            return Tipo+"|"+Nombre+"|"+Edad;

        }

        public double TotalAtenciones()
        {
            double importetotal = 0;
            foreach (Atención item in DetalleAtenciones)
                importetotal += item.Importe;
            return importetotal;
        }

        public int CantidadAtenciones()
        {
          int cantidad = 0;
          cantidad = DetalleAtenciones.Count();

            return cantidad;
        }


    }
}
