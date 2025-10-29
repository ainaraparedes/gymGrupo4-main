using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clasesGYM_;
using Microsoft.EntityFrameworkCore;
using clasesGYM_.Repositorios;

namespace frontGYM_.Reportes
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            dataGridClientes.ReadOnly = true;
            using (AplicationDbContext context = new AplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                dataGridClientes.DataSource = clientes;

                int cantidadActivos = clientes.Count(c => c.EstaActivo);
                txtActivos.Text = cantidadActivos.ToString();
            }



        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
