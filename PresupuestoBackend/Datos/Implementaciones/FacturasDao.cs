using PresupuestoBackend.Datos.Interfaces;
using PresupuestoBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBackend.Datos.Implementaciones
{
    public class FacturasDao : IFacturasDao
    {
        public List<Articulos> GetArticulos()
        {
            List<Articulos> lstArt = new List<Articulos>();
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_ARTICULOS");
            foreach (DataRow dr in tabla.Rows)
            {
                Articulos a = new Articulos();
                a.IdArticulo = Convert.ToInt32(dr["id_articulo"]);
                a.Nombre = Convert.ToString(dr["nombre"]);
                a.Precio = Convert.ToDouble(dr["precio_unitario"]);
                lstArt.Add(a);
            }
            return lstArt;
        }

        public List<FormaPago> GetFormaPago()
        {
            List<FormaPago> lst = new List<FormaPago>();
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_FORMA_P");
            foreach (DataRow dr in tabla.Rows)
            {
                FormaPago fp = new FormaPago();
                fp.IdFormaPago = Convert.ToInt32(dr["id_forma_pago"]);
                fp.Forma = Convert.ToString(dr["forma"]);
                lst.Add(fp);
            }
            return lst;
        }

        public bool CrearFacturas(Factura f)
        {
            return HelperDao.ObtenerInstancia().CrearMaestroDetalleFactura("SP_INSERTAR_MAESTRO", "SP_INSERTAR_DETALLE", f);
        }
    }
}

