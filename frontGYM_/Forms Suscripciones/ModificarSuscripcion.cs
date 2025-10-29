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

namespace frontGYM_.Forms_Suscripciones
{
    public partial class ModificarSuscripcion : Form
    {
        public ModificarSuscripcion()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Id.Text = dataGridView1.CurrentRow?.Cells["Id"].Value?.ToString();
            Nombre.Text = dataGridView1.CurrentRow?.Cells["Nombre"].Value?.ToString();
            Precio.Text = dataGridView1.CurrentRow?.Cells["Precio"].Value?.ToString();
        }

        private void ModificarSuscripcion_Load(object sender, EventArgs e)
        {
            Id.ReadOnly = true;
            RecargarDataGridView();
            
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void RecargarDataGridView()
        {
            // Cargar solo suscripciones activas
            var suscripciones = SuscripcionRepository.ObtenerSuscripcionesActivas();
            dataGridView1.DataSource = suscripciones;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione una suscripción para modificar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrWhiteSpace(Precio.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var suscripcionId = Convert.ToInt32(Id.Text);
                var suscripcionExistente = SuscripcionRepository.ObtenerSuscripcion(suscripcionId);
                
                if (suscripcionExistente == null)
                {
                    MessageBox.Show("Suscripción no encontrada.");
                    return;
                }

                // Actualizar los datos de la suscripción
                suscripcionExistente.Nombre = Nombre.Text.Trim();
                suscripcionExistente.Precio = decimal.Parse(Precio.Text);
                suscripcionExistente.EstaActivo = true; // Mantener activa

                // Guardar los cambios usando el repositorio
                SuscripcionRepository.ActualizarSuscripcion(suscripcionExistente);

                MessageBox.Show("Suscripción modificada con éxito.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un precio válido (solo números).");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la suscripción: {ex.Message}");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione una suscripción para eliminar.");
                    return;
                }

                var suscripcionId = Convert.ToInt32(Id.Text);
                var nombreSuscripcion = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();

                var resultado = MessageBox.Show($"¿Está seguro que desea eliminar (desactivar) la suscripción '{nombreSuscripcion}'?", 
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SuscripcionRepository.EliminarSuscripcion(suscripcionId);
                    MessageBox.Show("Suscripción eliminada (desactivada) con éxito.");
                    RecargarDataGridView();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la suscripción: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            Id.Text = "";
            Nombre.Text = "";
            Precio.Text = "";
        }
    }
}
