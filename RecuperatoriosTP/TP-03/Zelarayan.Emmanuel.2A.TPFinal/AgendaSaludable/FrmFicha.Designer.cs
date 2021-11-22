
namespace AgendaVista
{
    partial class FrmFicha
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblImc = new System.Windows.Forms.Label();
            this.lblGradoObesidad = new System.Windows.Forms.Label();
            this.lblCCorporal = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.progressBarIMC = new System.Windows.Forms.ProgressBar();
            this.progressBarGradoObesidad = new System.Windows.Forms.ProgressBar();
            this.progressBarComposicion = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgendaVista.Properties.Resources.png_transparent_computer_icons_user_profile_avatar_heroes_monochrome_black;
            this.pictureBox1.Location = new System.Drawing.Point(159, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 281);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 25);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(12, 337);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(51, 25);
            this.lblEdad.TabIndex = 2;
            this.lblEdad.Text = "Edad";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblSexo.Location = new System.Drawing.Point(15, 375);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(49, 25);
            this.lblSexo.TabIndex = 3;
            this.lblSexo.Text = "Sexo";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.Location = new System.Drawing.Point(11, 421);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(81, 25);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblPeso.Location = new System.Drawing.Point(12, 464);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(50, 25);
            this.lblPeso.TabIndex = 5;
            this.lblPeso.Text = "Peso";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblAltura.Location = new System.Drawing.Point(15, 514);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(62, 25);
            this.lblAltura.TabIndex = 6;
            this.lblAltura.Text = "Altura";
            // 
            // lblImc
            // 
            this.lblImc.AutoSize = true;
            this.lblImc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblImc.Location = new System.Drawing.Point(235, 464);
            this.lblImc.Name = "lblImc";
            this.lblImc.Size = new System.Drawing.Size(43, 25);
            this.lblImc.TabIndex = 7;
            this.lblImc.Text = "IMC";
            // 
            // lblGradoObesidad
            // 
            this.lblGradoObesidad.AutoSize = true;
            this.lblGradoObesidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblGradoObesidad.Location = new System.Drawing.Point(235, 375);
            this.lblGradoObesidad.Name = "lblGradoObesidad";
            this.lblGradoObesidad.Size = new System.Drawing.Size(163, 25);
            this.lblGradoObesidad.TabIndex = 8;
            this.lblGradoObesidad.Text = "Grado de obesidad";
            // 
            // lblCCorporal
            // 
            this.lblCCorporal.AutoSize = true;
            this.lblCCorporal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblCCorporal.Location = new System.Drawing.Point(235, 281);
            this.lblCCorporal.Name = "lblCCorporal";
            this.lblCCorporal.Size = new System.Drawing.Size(115, 25);
            this.lblCCorporal.TabIndex = 9;
            this.lblCCorporal.Text = "Composicion";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 619);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(481, 39);
            this.txtObservaciones.TabIndex = 10;
            this.txtObservaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblObservaciones.Location = new System.Drawing.Point(15, 591);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(138, 25);
            this.lblObservaciones.TabIndex = 11;
            this.lblObservaciones.Text = "Observaciones: ";
            // 
            // progressBarIMC
            // 
            this.progressBarIMC.BackColor = System.Drawing.Color.LemonChiffon;
            this.progressBarIMC.Location = new System.Drawing.Point(235, 505);
            this.progressBarIMC.Name = "progressBarIMC";
            this.progressBarIMC.Size = new System.Drawing.Size(261, 34);
            this.progressBarIMC.TabIndex = 12;
            // 
            // progressBarGradoObesidad
            // 
            this.progressBarGradoObesidad.BackColor = System.Drawing.Color.LemonChiffon;
            this.progressBarGradoObesidad.Location = new System.Drawing.Point(235, 412);
            this.progressBarGradoObesidad.Name = "progressBarGradoObesidad";
            this.progressBarGradoObesidad.Size = new System.Drawing.Size(261, 34);
            this.progressBarGradoObesidad.TabIndex = 13;
            // 
            // progressBarComposicion
            // 
            this.progressBarComposicion.BackColor = System.Drawing.Color.LemonChiffon;
            this.progressBarComposicion.Location = new System.Drawing.Point(235, 328);
            this.progressBarComposicion.Name = "progressBarComposicion";
            this.progressBarComposicion.Size = new System.Drawing.Size(261, 34);
            this.progressBarComposicion.TabIndex = 14;
            // 
            // FrmFicha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(508, 692);
            this.Controls.Add(this.progressBarComposicion);
            this.Controls.Add(this.progressBarGradoObesidad);
            this.Controls.Add(this.progressBarIMC);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblCCorporal);
            this.Controls.Add(this.lblGradoObesidad);
            this.Controls.Add(this.lblImc);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFicha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha de Contacto";
            this.Load += new System.EventHandler(this.FrmFicha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblImc;
        private System.Windows.Forms.Label lblGradoObesidad;
        private System.Windows.Forms.Label lblCCorporal;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.ProgressBar progressBarIMC;
        private System.Windows.Forms.ProgressBar progressBarGradoObesidad;
        private System.Windows.Forms.ProgressBar progressBarComposicion;
    }
}