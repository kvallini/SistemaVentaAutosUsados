namespace SistemaVentaAutosUsados
{
    partial class frmMenuCliente
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Controls.Add(this.button1);
            this.panelContenedor.Controls.Add(this.btnCitas);
            this.panelContenedor.Controls.Add(this.btnServicios);
            this.panelContenedor.Controls.Add(this.btnCatalogo);
            this.panelContenedor.Controls.Add(this.lblBienvenida);
            this.panelContenedor.Location = new System.Drawing.Point(50, 30);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(400, 400);
            this.panelContenedor.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(50, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "CERRAR SESIÓN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCitas.ForeColor = System.Drawing.Color.White;
            this.btnCitas.Location = new System.Drawing.Point(50, 230);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(300, 50);
            this.btnCitas.TabIndex = 3;
            this.btnCitas.Text = "SOLICITAR CITA";
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.SeaGreen;
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Location = new System.Drawing.Point(50, 160);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(300, 50);
            this.btnServicios.TabIndex = 2;
            this.btnServicios.Text = "SERVICIOS ADICIONALES";
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.Color.White;
            this.btnCatalogo.Location = new System.Drawing.Point(50, 90);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(300, 50);
            this.btnCatalogo.TabIndex = 1;
            this.btnCatalogo.Text = " CATÁLOGO DE VEHÍCULOS";
            this.btnCatalogo.UseVisualStyleBackColor = false;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblBienvenida.Location = new System.Drawing.Point(80, 30);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(240, 25);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido, (Nombre)";
            this.lblBienvenida.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmMenuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContenedor);
            this.Name = "frmMenuCliente";
            this.Text = "frmMenuCliente";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Button button1;


    }
}