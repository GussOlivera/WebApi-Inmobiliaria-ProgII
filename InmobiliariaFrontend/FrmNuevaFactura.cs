using Newtonsoft.Json;
using PresupuestoBackend.Datos;
using PresupuestoBackend.Dominio;
using PresupuestoBackend.Servicios;
using PresupuestoBackend.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InmobiliariaFrontend
{
    public partial class FrmNuevaFactura : Form
    {
        private IServicio oServicio;
        private FabricaServicio oFabrica;
        private Factura f;

        public FrmNuevaFactura()
        {
            InitializeComponent();
            oFabrica = new FabricaServicioImp();
            oServicio = oFabrica.CrearServicio();
            f = new Factura();
        }

        private async void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            await CargarArticulosAsync();
            await CargarFormaPAsync();
            numCantidad.Value = 1;
            txtCliente.Text = "Consumidor Final";

        }

        private async Task CargarFormaPAsync()
        {
            string url = "https://localhost:7112/formaPago";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            List<FormaPago> lst = JsonConvert.DeserializeObject<List<FormaPago>>(data);
            cboFormaPago.DataSource = lst;
            cboFormaPago.ValueMember = "IdFormaPago";
            cboFormaPago.DisplayMember = "Forma";
            cboFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task CargarArticulosAsync()
        {
            string url = "https://localhost:7112/articulos";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            List<Articulos> lst = JsonConvert.DeserializeObject<List<Articulos>>(data);
            cboArticulo.DataSource = lst;
            cboArticulo.ValueMember = "IdArticulo";
            cboArticulo.DisplayMember = "Nombre";
            cboArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                foreach (DataGridViewRow item in dgvDetalles.Rows)
                {
                    if (item.Cells["ColArticulo"].Value.ToString().Equals(cboArticulo.Text))
                    {
                        MessageBox.Show("Articulo: " + cboArticulo.Text + " ya se encuentra como detalle", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                Articulos a = (Articulos)cboArticulo.SelectedItem;

                int cantidad = Convert.ToInt32(numCantidad.Value);
                
                DetalleFactura detalle = new DetalleFactura(a, cantidad);
                f.AgregarDetalle(detalle);
                dgvDetalles.Rows.Add(new object[] { f.NroFactura, a.Nombre, a.Precio, numCantidad.Value });
                CalcularTotal();

            
        }

        private void CalcularTotal()
        {
            double total = f.CalcularTotal();
            txtTotal.Text = total.ToString();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            f.Cliente = txtCliente.Text;
            f.FormaPago = (FormaPago)cboFormaPago.SelectedItem;

            var save = await GuardarFacturaAsync(f);
            if (save)
            {
                MessageBox.Show("Se pudo");
            }
            
        }

        private async Task<bool> GuardarFacturaAsync(Factura f)
        {
            string url = "https://localhost:7112/anadirFactura";
            string facturaJson = JsonConvert.SerializeObject(f);

            var result = await ClientSingleton.GetInstancia().PostAsync(url, facturaJson);
            return result.Equals("true");
        }
    }
}
