using Alta_Recetas.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Recetas.datos.Interfaz
{
    public interface IDaoReceta
    {
        int ObtenerProximoNro();

        List<Ingrediente> ObtenerIngrediente();
    }
}
