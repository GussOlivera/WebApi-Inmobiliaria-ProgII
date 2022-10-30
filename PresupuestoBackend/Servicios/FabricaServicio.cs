using PresupuestoBackend.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Servicios
{
    public abstract class FabricaServicio
    {
        public abstract IServicio CrearServicio();


    }


}
