using BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Negocio
{
    public interface InterfaceGestor
    {
        List<TipoCarga> GetTipoCargaList();

        int GetNroProximoCamion();
        bool CargarCamion(Camion oCamion);
    }
}
