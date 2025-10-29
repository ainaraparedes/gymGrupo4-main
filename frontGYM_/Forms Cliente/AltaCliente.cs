using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using clasesGYM_;
using clasesGYM_.Repositorios;  

namespace frontGYM_
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Click(object sender, EventArgs e)
        {
            try
            {
                var tipoSuscripcion = comboBox1.SelectedItem as Suscripcion;
                if (tipoSuscripcion == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de suscripción.");
                    return;
                }

                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrWhiteSpace(Apellido.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                // Crear cliente con suscripción asignada directamente
                var nuevoCliente = new Cliente
                {
                    Dni = int.Parse(Dni.Text),
                    Direccion = Direccion.Text,
                    Nombre = Nombre.Text.Trim(),
                    Apellido = Apellido.Text.Trim(),
                    Telefono = int.Parse(Telefono.Text),
                    SuscripcionId = tipoSuscripcion.Id,  // Asignar directamente el ID de la suscripción
                    FechaInicio = FechaInicio.Value,     // Usar la fecha seleccionada
                    EstaActivo = true  // Se establecerá automáticamente en el repositorio, pero es buena práctica
                };

                // Usar el método simplificado del ClienteRepository
                ClienteRepository.AgregarCliente(nuevoCliente);

                MessageBox.Show("Cliente registrado con éxito.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para DNI y Teléfono.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cliente: {ex.Message}");
            }
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            // Cargar solo suscripciones activas en el comboBox
            comboBox1.DataSource = SuscripcionRepository.ObtenerSuscripcionesActivas();
            comboBox1.DisplayMember = "Nombre";
        }
    }
}