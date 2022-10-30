using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using PresupuestoBackend.Dominio;

namespace PresupuestoBackend.Datos
{
    internal class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection cnn;

        private HelperDao()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-O24O5E7\SQLEXPRESS01;Initial Catalog=Minimercado;Integrated Security=True");
        }
        public static HelperDao ObtenerInstancia()
        {
            if(instancia == null)
                instancia = new HelperDao();
            return instancia;
        }
        public DataTable ConsultaSQL(string NombreSP)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            cmd.Connection = cnn;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;

        }
        public bool CrearMaestroDetalleFactura(string spMaestro, string spDetalle, Factura f)
        {
            bool ok = false;
            SqlTransaction transaccion = null;
            try
            {
                cnn.Open();
                transaccion = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(spMaestro, cnn, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro_factura", f.NroFactura);
                cmd.Parameters.AddWithValue("@formaPago", f.FormaPago);
                cmd.Parameters.AddWithValue("@cliente", f.Cliente);

                cmd.ExecuteNonQuery();

              
                foreach (DetalleFactura df in f.Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand(spDetalle, cnn, transaccion);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_factura", f.NroFactura);
                    cmdDetalle.Parameters.AddWithValue("@articulo", df.Articulo.IdArticulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", df.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }
                transaccion.Commit();
                ok = true;


            }
            catch (Exception)
            {
                if (transaccion != null)
                    transaccion.Rollback();

            }
            finally
            {
                cnn.Close();
            }

            return ok;
        }


        public SqlConnection ObtenerConexion()
        {
            return this.cnn;
        }
    }
}
