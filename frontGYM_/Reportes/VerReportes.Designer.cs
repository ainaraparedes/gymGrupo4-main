namespace frontGYM_.Reportes
{
    partial class VerReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerReportes));
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            Volver = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(47, 182);
            button1.Name = "button1";
            button1.Size = new Size(288, 51);
            button1.TabIndex = 0;
            button1.Text = "Ver Clientes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(455, 182);
            button2.Name = "button2";
            button2.Size = new Size(288, 51);
            button2.TabIndex = 1;
            button2.Text = "Ver Ganancias";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(265, 78);
            label6.Name = "label6";
            label6.Size = new Size(291, 20);
            label6.TabIndex = 22;
            label6.Text = "VER REPORTES DISPONIBLES";
            // 
            // Volver
            // 
            Volver.BackColor = Color.Red;
            Volver.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Volver.ForeColor = SystemColors.ControlLightLight;
            Volver.Location = new Point(633, 366);
            Volver.Name = "Volver";
            Volver.Size = new Size(110, 42);
            Volver.TabIndex = 23;
            Volver.Text = "volver!";
            Volver.UseVisualStyleBackColor = false;
            Volver.Click += Volver_Click;
            // 
            // VerReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Volver);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VerReportes";
            Text = "VerReportes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label6;
        private Button Volver;
    }
}