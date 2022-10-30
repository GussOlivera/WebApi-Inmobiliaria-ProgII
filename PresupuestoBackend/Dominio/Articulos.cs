using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Dominio
{
    public class Articulos
    {
       
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
