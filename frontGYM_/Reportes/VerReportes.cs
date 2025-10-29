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
    public partial class VerReportes : Form
    {
        public VerReportes()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Clientes clientes = new Clientes()) { clientes.ShowDialog(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Ganancias ganancias = new Ganancias()) { ganancias.ShowDialog(); }
        }
    }
}
