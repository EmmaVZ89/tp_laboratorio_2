
namespace AgendaVista
{
    partial class FrmEstadisticas
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
            this.lblEstadisticas = new System.Windows.Forms.Label();
            this.cmbEstadisticas = new System.Windows.Forms.ComboBox();
            this.rtbEstadisticas = new System.Windows.Forms.RichTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardarComo = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.AutoSize = true;
            this.lblEstadisticas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblEstadisticas.Location = new System.Drawing.Point(12, 44);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new System.Drawing.Size(114, 25);
            this.lblEstadisticas.TabIndex = 0;
            this.lblEstadisticas.Text = "Estadisticas: ";
            // 
            // cmbEstadisticas
            // 
            this.cmbEstadisticas.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbEstadisticas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadisticas.FormattingEnabled = true;
            this.cmbEstadisticas.Location = new System.Drawing.Point(129, 36);
            this.cmbEstadisticas.Name = "cmbEstadisticas";
            this.cmbEstadisticas.Size = new System.Drawing.Size(466, 33);
            this.cmbEstadisticas.TabIndex = 1;
            // 
            // rtbEstadisticas
            // 
            this.rtbEstadisticas.BackColor = System.Drawing.Color.LemonChiffon;
            this.rtbEstadisticas.Location = new System.Drawing.Point(12, 106);
            this.rtbEstadisticas.Name = "rtbEstadisticas";
            this.rtbEstadisticas.Size = new System.Drawing.Size(832, 424);
            this.rtbEstadisticas.TabIndex = 2;
            this.rtbEstadisticas.Text = "";
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.Ivory;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnAbrir.Location = new System.Drawing.Point(480, 549);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(162, 41);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir informe";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.BackColor = System.Drawing.Color.Ivory;
            this.btnGuardarComo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarComo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnGuardarComo.Location = new System.Drawing.Point(682, 549);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(162, 41);
            this.btnGuardarComo.TabIndex = 4;
            this.btnGuardarComo.Text = "Guardar Informe";
            this.btnGuardarComo.UseVisualStyleBackColor = false;
            this.btnGuardarComo.Click += new System.EventHandler(this.btnGuardarComo_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.Color.Ivory;
            this.btnAnalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnalizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnAnalizar.Location = new System.Drawing.Point(623, 36);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(221, 34);
            this.btnAnalizar.TabIndex = 5;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(855, 601);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnGuardarComo);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.rtbEstadisticas);
            this.Controls.Add(this.cmbEstadisticas);
            this.Controls.Add(this.lblEstadisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisis de datos";
            this.Load += new System.EventHandler(this.FrmEstadisticas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.ComboBox cmbEstadisticas;
        private System.Windows.Forms.RichTextBox rtbEstadisticas;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardarComo;
        private System.Windows.Forms.Button btnAnalizar;
    }
}