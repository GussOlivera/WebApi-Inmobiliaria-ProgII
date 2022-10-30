using PresupuestoBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Datos.Interfaces
{
    public interface IFacturasDao
    {
        
        List<FormaPago> GetFormaPago();
        List<Articulos> GetArticulos();
        bool CrearFacturas(Factura f); 

    }
}
