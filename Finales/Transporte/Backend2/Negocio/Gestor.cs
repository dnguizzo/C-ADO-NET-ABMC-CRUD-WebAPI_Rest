using BackEnd.Datos;
using BackEnd.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Negocio
{
    public class Gestor : InterfaceGestor
    {
        public InterfaceDAO dao;

        public Gestor() {
         dao = new CamionDAO();
        }
        public List<TipoCarga> GetTipoCargaList()
        {
            return dao.GetTipoCargaList();
        }

        public int GetNroProximoCamion()
        {
            return dao.GetNroProximo();
        }
        public bool CargarCamion(Camion oCamion)
        {
            return dao.CargarCamion(oCamion);
        }
    }
}
