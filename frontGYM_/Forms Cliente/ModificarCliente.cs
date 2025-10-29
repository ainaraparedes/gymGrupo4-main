using clasesGYM_;
using clasesGYM_.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontGYM_
{
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            // Cargar datos usando el método optimizado
            RecargarDataGridView();
            
            // Configurar el DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            
            // Cargar suscripciones activas para el comboBox
            var suscripciones = SuscripcionRepository.ObtenerSuscripcionesActivas();
            comboBoxSuscripcion.DataSource = suscripciones;
            comboBoxSuscripcion.DisplayMember = "Nombre";
            comboBoxSuscripcion.ValueMember = "Id";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                // Llenar todos los campos con los datos del cliente seleccionado
                Nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
                Apellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value?.ToString() ?? "";
                Direccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value?.ToString() ?? "";
                Telefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value?.ToString() ?? "";
                Dni.Text = dataGridView1.CurrentRow.Cells["Dni"].Value?.ToString() ?? "";
                
                // Obtener el ID de la suscripción (aunque esté oculta, sigue estando disponible)
                var suscripcionId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SuscripcionId"].Value);
                comboBoxSuscripcion.SelectedValue = suscripcionId;
                
                // Mostrar estado activo
                var estaActivo = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["EstaActivo"].Value);
                checkBoxActivo.Checked = estaActivo;
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un cliente
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un cliente de la lista.");
                    return;
                }

                // Obtener datos del cliente seleccionado
                var clienteId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                var nombreCliente = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();
                var apellidoCliente = dataGridView1.CurrentRow.Cells["Apellido"].Value?.ToString();

                // Confirmar eliminación
                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar (desactivar) al cliente {nombreCliente} {apellidoCliente}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Realizar eliminación lógica usando el repositorio
                    ClienteRepository.EliminarCliente(clienteId);

                    MessageBox.Show("Cliente eliminado (desactivado) con éxito.");
                    
                    // Recargar la lista de clientes
                    RecargarDataGridView();
                    
                    // Limpiar los campos
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            Nombre.Text = "";
            Apellido.Text = "";
            Direccion.Text = "";
            Telefono.Text = "";
            Dni.Text = "";
            comboBoxSuscripcion.SelectedIndex = -1;
            checkBoxActivo.Checked = false;
            // FechaInicio NO se limpia - se mantiene para mostrar
        }

        private void RecargarDataGridView()
        {
            // Versión optimizada: JOIN directo en la base de datos usando Entity Framework
            using (var context = new AplicationDbContext())
            {
                var clientesConSuscripcion = (from cliente in context.Clientes
                                            join suscripcion in context.Suscripciones 
                                            on cliente.SuscripcionId equals suscripcion.Id
                                            select new
                                            {
                                                cliente.Id,
                                                cliente.Dni,
                                                cliente.Nombre,
                                                cliente.Apellido,
                                                cliente.Direccion,
                                                cliente.Telefono,
                                                cliente.SuscripcionId,
                                                NombreSuscripcion = suscripcion.Nombre,
                                                cliente.EstaActivo
                                            }).ToList();

                dataGridView1.DataSource = clientesConSuscripcion;
                
                // Ocultar la columna SuscripcionId
                if (dataGridView1.Columns["SuscripcionId"] != null)
                    dataGridView1.Columns["SuscripcionId"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un cliente
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un cliente de la lista.");
                    return;
                }

                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrWhiteSpace(Apellido.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                // Obtener el cliente seleccionado
                var clienteId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                var clienteExistente = ClienteRepository.ObtenerCliente(clienteId);
                
                if (clienteExistente == null)
                {
                    MessageBox.Show("No se pudo encontrar el cliente seleccionado.");
                    return;
                }

                // Actualizar los datos del cliente
                clienteExistente.Nombre = Nombre.Text.Trim();
                clienteExistente.Apellido = Apellido.Text.Trim();
                clienteExistente.Direccion = Direccion.Text.Trim();
                clienteExistente.Telefono = int.Parse(Telefono.Text);
                clienteExistente.SuscripcionId = Convert.ToInt32(comboBoxSuscripcion.SelectedValue);
                clienteExistente.EstaActivo = checkBoxActivo.Checked;

                // Guardar los cambios usando el repositorio
                ClienteRepository.ActualizarCliente(clienteExistente);

                MessageBox.Show("Cliente modificado con éxito.");
                
                // Recargar la lista de clientes
                RecargarDataGridView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para Teléfono.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el cliente: {ex.Message}");
            }
        }
    }
}
