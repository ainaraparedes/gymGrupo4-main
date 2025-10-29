using clasesGYM_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clasesGYM_.Repositorios;

namespace frontGYM_.Pago
{
    public partial class CargarPago : Form
    {
        public CargarPago()
        {
            InitializeComponent();
        }

        private void CargarPago_Load(object sender, EventArgs e)
        {
                Id.ReadOnly = true;
            Nombre.ReadOnly = true;
            Apellido.ReadOnly = true;
            Fecha.Enabled = false;
                textBoxSuscripcion.ReadOnly = true;
                textBoxPrecio.ReadOnly = true;
            using (AplicationDbContext context = new AplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                dataGridView1.DataSource = clientes;
                comboBoxPago.DataSource = Enum.GetValues(typeof(clasesGYM_.Pagos.MetodoDePago));
            }
        }

        private void Apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Id.Text = dataGridView1.CurrentRow.Cells["Id"]?.Value?.ToString();
            Nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"]?.Value?.ToString();
            Apellido.Text = dataGridView1.CurrentRow.Cells["Apellido"]?.Value?.ToString();
            Fecha.Text = dataGridView1.CurrentRow.Cells["FechaInicio"]?.Value?.ToString();
            textBoxSuscripcion.Text = dataGridView1.CurrentRow.Cells["SuscripcionId"]?.Value?.ToString();
            int suscripcionId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SuscripcionId"]?.Value);
            textBoxSuscripcion.Text = suscripcionId.ToString();
            // Obtener el monto desde la base de datos
            decimal monto = SuscripcionRepository.ObtenerPrecioSuscripcion(suscripcionId);
            textBoxPrecio.Text = monto.ToString("C"); // Formato moneda



        }

        private void Pago_Click(object sender, EventArgs e)
        {
            // Validar que SelectedValue no sea null y convertir a string
            var metodoPagoEnum = comboBoxPago.SelectedValue as clasesGYM_.Pagos.MetodoDePago?;
            if (metodoPagoEnum == null)
            {
                MessageBox.Show("Seleccione un método de pago válido.");
                return;
            }

            Pagos nuevoPago = new Pagos
            {
                ClienteId = int.Parse(Id.Text),
                FechaPago = Fecha.Value,
                Monto = SuscripcionRepository.ObtenerPrecioSuscripcion(int.Parse(textBoxSuscripcion.Text)),
                MetodoPago = metodoPagoEnum.Value.ToString(), // Convertir enum a string
                Metodo = metodoPagoEnum.Value // Asignar enum al campo correspondiente
            };
            PagoRepository.RegistrarPago(nuevoPago);
            MessageBox.Show("Pago registrado con éxito.");
            this.Close();
        }
    }
}
