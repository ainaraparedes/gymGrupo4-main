using clasesGYM_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontGYM_.Reportes
{
    public partial class Ganancias : Form
    {
        public Ganancias()
        {
            InitializeComponent();
        }

        private void Ganancias_Load(object sender, EventArgs e)
        {
            dataGridPagos.ReadOnly = true;
            using (AplicationDbContext context = new AplicationDbContext())
            {
                var pagos = context.Pagos.ToList();
                dataGridPagos.DataSource = pagos;
            }
            decimal total = 0;

            foreach (DataGridViewRow fila in dataGridPagos.Rows)
            {
                // Evita filas nuevas vacías
                if (!fila.IsNewRow)
                {
                    // Intenta convertir el valor de la celda a decimal
                    object valorCelda = fila.Cells["Monto"].Value;
                    if (valorCelda != null && decimal.TryParse(valorCelda.ToString(), out decimal monto))
                    {
                        total += monto;
                    }
                }
            }
            txtPagos.Text = total.ToString("C"); // "C" para formato moneda
        }



        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
