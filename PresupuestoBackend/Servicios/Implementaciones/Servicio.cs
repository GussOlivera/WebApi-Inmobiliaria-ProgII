using PresupuestoBackend.Datos.Implementaciones;
using PresupuestoBackend.Datos.Interfaces;
using PresupuestoBackend.Dominio;
using PresupuestoBackend.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Servicios.Implementaciones
{
    internal class Servicio : IServicio
    {
        private IFacturasDao oDao;
        public Servicio()
        {
            oDao = new FacturasDao();
        }

        public List<Articulos> GetArticulos()
        {
            return oDao.GetArticulos();
        }

        public List<FormaPago> GetFormaPago()
        {
            return oDao.GetFormaPago();
        }

        public bool CrearFacturas(Factura f)
        {
            return oDao.CrearFacturas(f);
        }
    }
}
