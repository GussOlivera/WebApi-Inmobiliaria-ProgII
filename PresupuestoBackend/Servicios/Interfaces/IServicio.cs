using PresupuestoBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Servicios.Interfaces
{
    public interface IServicio
    {
        bool CrearFacturas(Factura f);
        List<FormaPago> GetFormaPago();
        List<Articulos> GetArticulos();
    }
}
