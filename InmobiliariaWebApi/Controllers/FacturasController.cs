using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestoBackend.Dominio;
using PresupuestoBackend.Servicios;
using PresupuestoBackend.Servicios.Interfaces;

namespace InmobiliariaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IServicio oServicio;
        private FabricaServicio oFabrica;

        public FacturasController()
        {
            oFabrica = new FabricaServicioImp();
            oServicio = oFabrica.CrearServicio();
        }
        [HttpPost]
        public IActionResult PostFacturas(Factura f)
        {
            if (f == null)
                return BadRequest();
            if (oServicio.CrearFacturas(f))
                return Ok("Se registro con exito");
            else
                return BadRequest("No se pudo registrar");
        }
 

    }
}
