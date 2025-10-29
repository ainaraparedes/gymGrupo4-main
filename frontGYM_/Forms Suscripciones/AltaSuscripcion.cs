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
    public partial class AltaSuscripcion : Form
    {
        private void AltaSuscripcion_Load(object sender, EventArgs e)
        {

        }
        public AltaSuscripcion()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(Nombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre de la suscripción.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Precio.Text))
                {
                    MessageBox.Show("Por favor, ingrese el precio de la suscripción.");
                    return;
                }

                // Validar que no exista una suscripción con el mismo nombre
                var nombreNormalizado = Nombre.Text.Trim().ToUpper();
                var suscripcionesExistentes = SuscripcionRepository.ObtenerSuscripciones();
                
                foreach (var suscripcion in suscripcionesExistentes)
                {
                    if (suscripcion.Nombre.ToUpper() == nombreNormalizado)
                    {
                        MessageBox.Show($"Ya existe una suscripción con el nombre '{nombreNormalizado}'. Use el formulario de modificación para reactivarla.");
                        return;
                    }
                }

                // Crear nueva suscripción
                var nuevaSuscripcion = new Suscripcion
                {
                    Nombre = Nombre.Text.Trim().ToUpper(), // Convertir a mayúsculas
                    Precio = decimal.Parse(Precio.Text),
                    EstaActivo = true  // Se establecerá automáticamente en el repositorio, pero es buena práctica
                };

                // Usar el repositorio para agregar la suscripción
                SuscripcionRepository.AgregarSuscripcion(nuevaSuscripcion);
                
                MessageBox.Show("Suscripción registrada con éxito.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un precio válido (solo números).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la suscripción: {ex.Message}");
            }
        }
    }
}