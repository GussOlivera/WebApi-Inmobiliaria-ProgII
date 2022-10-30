using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Dominio
{
    public class DetalleFactura
    {
        
        public DetalleFactura(Articulos a, int cant)
        {            
            Articulo = a;
            Cantidad = cant;
            
        }
        public Articulos Articulo { get; set; }
        public int Cantidad { get; set; }
        
        public double calcularSubtotal()
        {
            return Articulo.Precio * Cantidad;
        }

    }
}
