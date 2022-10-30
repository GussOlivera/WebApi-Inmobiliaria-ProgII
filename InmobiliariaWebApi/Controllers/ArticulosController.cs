using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestoBackend.Dominio;
using PresupuestoBackend.Servicios.Interfaces;
using PresupuestoBackend.Servicios;

namespace InmobiliariaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {

        private IServicio oServicio;
        private FabricaServicio oFabrica;

        public ArticulosController()
        {
            oFabrica = new FabricaServicioImp();
            oServicio = oFabrica.CrearServicio();
        }

        [HttpGet("/articulos")]
        public List<Articulos> GetArticulos()
        {
            return oServicio.GetArticulos();
        }
        [HttpGet("/formaPago")]
        public List<FormaPago> GetFormaPago()
        {
            return oServicio.GetFormaPago();
        }
    }
}
