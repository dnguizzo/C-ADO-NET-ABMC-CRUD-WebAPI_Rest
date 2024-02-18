using BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos
{
    public interface InterfaceDAO
    {
        List<TipoCarga> GetTipoCargaList();
        int GetNroProximo();
        bool CargarCamion(Camion oCamion);

    }
}
