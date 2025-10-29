namespace frontGYM_.Reportes
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Volver = new Button();
            dataGridClientes = new DataGridView();
            label6 = new Label();
            txtActivos = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            SuspendLayout();
            // 
            // Volver
            // 
            Volver.BackColor = Color.Red;
            Volver.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Volver.ForeColor = SystemColors.ControlLightLight;
            Volver.Location = new Point(609, 381);
            Volver.Name = "Volver";
            Volver.Size = new Size(105, 36);
            Volver.TabIndex = 51;
            Volver.Text = "volver!";
            Volver.UseVisualStyleBackColor = false;
            Volver.Click += Volver_Click;
            // 
            // dataGridClientes
            // 
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(87, 92);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.RowHeadersWidth = 51;
            dataGridClientes.Size = new Size(627, 188);
            dataGridClientes.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(347, 33);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 49;
            label6.Text = "CLIENTES";
            // 
            // txtActivos
            // 
            txtActivos.Location = new Point(195, 308);
            txtActivos.Name = "txtActivos";
            txtActivos.Size = new Size(204, 27);
            txtActivos.TabIndex = 53;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 311);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 52;
            label1.Text = "Total Clientes";
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtActivos);
            Controls.Add(label1);
            Controls.Add(Volver);
            Controls.Add(dataGridClientes);
            Controls.Add(label6);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Volver;
        private DataGridView dataGridClientes;
        private Label label6;
        private TextBox txtActivos;
        private Label label1;
    }
}