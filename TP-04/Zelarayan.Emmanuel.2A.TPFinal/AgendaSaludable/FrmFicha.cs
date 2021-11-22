using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AgendaVista
{
    public partial class FrmFicha : Form
    {
        Contacto contacto;

        /// <summary>
        /// Contructor por defecto de un FrmFicha
        /// </summary>
        public FrmFicha()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor con parametros de un FrmFicha
        /// </summary>
        /// <param name="contacto">contacto a cargar en el campo contacto</param>
        public FrmFicha(Contacto contacto):this()
        {
            this.contacto = contacto;
        }

        /// <summary>
        /// Evento FrmFicha_Load, encargado de cargar todos los datos del contacto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFicha_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = $"Nombre: {this.contacto.Nombre}";
            this.lblEdad.Text = $"Edad: {this.contacto.Edad}";
            this.lblTelefono.Text = $"Telefono: {this.contacto.Telefono}";
            this.lblSexo.Text = $"Sexo: {this.contacto.Sexo}";
            this.lblPeso.Text = $"Peso: {this.contacto.Peso} Kg";
            this.lblAltura.Text = $"Altura: {this.contacto.Altura} Mt";
            this.lblImc.Text = $"IMC: {this.contacto.Imc}";
            this.lblCCorporal.Text = $"Composicion: {this.contacto.ComposicionCorporal}";
            this.lblGradoObesidad.Text = $"Grado de obesidad: {this.contacto.GradoObesidad}";
            this.CalcularProgressBarComposicionYObservaciones();
            this.CalcularProgressBarGradoObesidad();
            this.CalcularProgressBarIMC();
            this.txtObservaciones.ReadOnly = true;
        }

        /// <summary>
        /// Calcula el nivel de la progressBar de la composicion y agrega un mensaje
        /// en el listbox de observaciones
        /// </summary>
        private void CalcularProgressBarComposicionYObservaciones()
        {
            if (this.contacto.Imc < 18.5)
            {
                this.txtObservaciones.BackColor = Color.LightSkyBlue;
                this.txtObservaciones.ForeColor = Color.Blue;
                this.txtObservaciones.Text = "Es hora de comer un poco mas.";
                this.progressBarComposicion.Value = 25;
            }
            else if (this.contacto.Imc >= 18.5 && this.contacto.Imc <= 24.9)
            {
                this.txtObservaciones.BackColor = Color.LightGreen;
                this.txtObservaciones.ForeColor = Color.Green;
                this.txtObservaciones.Text = "Estas en tu peso saludable, felicitaciones!";
                this.progressBarComposicion.Value = 50;
            }
            else if (this.contacto.Imc >= 25 && this.contacto.Imc <= 29.9)
            {
                this.txtObservaciones.BackColor = Color.LightYellow;
                this.txtObservaciones.ForeColor = Color.Orange;
                this.txtObservaciones.Text = "Ten cuidado con que te alimentas.";
                this.progressBarComposicion.Value = 75;
            }
            else
            {
                this.txtObservaciones.BackColor = Color.Orange;
                this.txtObservaciones.ForeColor = Color.Red;
                this.txtObservaciones.Text = "Es hora de empezar a cuidarte!";
                this.progressBarComposicion.Value = 100;
            }
        }

        /// <summary>
        /// Calcula el nivel de la progressBar del grado de obesidad
        /// </summary>
        private void CalcularProgressBarGradoObesidad()
        {
            switch (this.contacto.GradoObesidad)
            {
                case EGradoObesidad.No_Obeso:
                    this.progressBarGradoObesidad.Value = 10;
                    break;
                case EGradoObesidad.Grado_1:
                    this.progressBarGradoObesidad.Value = 25;
                    break;
                case EGradoObesidad.Grado_2:
                    this.progressBarGradoObesidad.Value = 65;
                    break;
                case EGradoObesidad.Grado_3:
                    this.progressBarGradoObesidad.Value = 100;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Calcula el nivel de la progressBar del IMC
        /// </summary>
        private void CalcularProgressBarIMC()
        {
            if(this.contacto.Imc < 100)
            {
                this.progressBarIMC.Value = (int)this.contacto.Imc;
            }
        }
    }
}
