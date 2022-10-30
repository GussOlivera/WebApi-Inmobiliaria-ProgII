using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Dominio
{
    public class FormaPago
    {
        public int IdFormaPago { get; set; }
        public string Forma { get; set; }

        public override string ToString()
        {
            return Forma;
        }

    }
}
