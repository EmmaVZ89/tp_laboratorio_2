using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AgendaVista
{
    public partial class FrmFicha : Form
    {
        Contacto contacto;
        private CancellationTokenSource cts;
        private List<Task> hilosBarras;

        /// <summary>
        /// Contructor por defecto de un FrmFicha
        /// </summary>
        public FrmFicha()
        {
            InitializeComponent();
            this.hilosBarras = new List<Task>();
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
            this.IniciarBarras();
            this.lblNombre.Text = $"Nombre: {this.contacto.Nombre}";
            this.lblEdad.Text = $"Edad: {this.contacto.Edad}";
            this.lblTelefono.Text = $"Telefono: {this.contacto.Telefono}";
            this.lblSexo.Text = $"Sexo: {this.contacto.Sexo}";
            this.lblPeso.Text = $"Peso: {this.contacto.Peso} Kg";
            this.lblAltura.Text = $"Altura: {this.contacto.Altura} Mt";
            this.lblImc.Text = $"IMC: {this.contacto.Imc}";
            this.lblCCorporal.Text = $"Composicion: {this.contacto.ComposicionCorporal}";
            this.lblGradoObesidad.Text = $"Grado de obesidad: {this.contacto.GradoObesidad}";
            this.txtObservaciones.ReadOnly = true;
        }

        /// <summary>
        /// Calcula el nivel de la progressBar de la composicion y agrega un mensaje
        /// en el listbox de observaciones
        /// </summary>
        private int CalcularProgressBarComposicion()
        {
            int retorno;
            if (this.contacto.Imc < 18.5)
            {
                retorno = 25;
            }
            else if (this.contacto.Imc >= 18.5 && this.contacto.Imc <= 24.9)
            {
                retorno = 50;
            }
            else if (this.contacto.Imc >= 25 && this.contacto.Imc <= 29.9)
            {
                retorno = 75;
            }
            else
            {
                retorno = 100;
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="barraProgreso"></param>
        private void MostrarMensajeObservacion(ProgressBar barraProgreso)
        {
            if (this.InvokeRequired)
            {
                Action<ProgressBar> delegado = MostrarMensajeObservacion;
                object[] parametros = new object[] { barraProgreso };
                this.Invoke(delegado, parametros);
            }
            else
            {
                if (barraProgreso.Value <= 25)
                {
                    this.txtObservaciones.BackColor = Color.LightSkyBlue;
                    this.txtObservaciones.ForeColor = Color.Blue;
                    this.txtObservaciones.Text = "Es hora de comer un poco mas.";
                }
                else if (barraProgreso.Value > 25 && barraProgreso.Value <= 50)
                {
                    this.txtObservaciones.BackColor = Color.LightGreen;
                    this.txtObservaciones.ForeColor = Color.Green;
                    this.txtObservaciones.Text = "Estas en tu peso saludable, felicitaciones!";
                }
                else if (barraProgreso.Value > 50 && barraProgreso.Value <= 75)
                {
                    this.txtObservaciones.BackColor = Color.LightYellow;
                    this.txtObservaciones.ForeColor = Color.Orange;
                    this.txtObservaciones.Text = "Ten cuidado con que te alimentas.";
                }
                else
                {
                    this.txtObservaciones.BackColor = Color.Orange;
                    this.txtObservaciones.ForeColor = Color.Red;
                    this.txtObservaciones.Text = "Es hora de empezar a cuidarte!";
                }
            }
        }

        /// <summary>
        /// Calcula el nivel de la progressBar del grado de obesidad
        /// </summary>
        private int CalcularProgressBarGradoObesidad()
        {
            int retorno = 0;
            switch (this.contacto.GradoObesidad)
            {
                case EGradoObesidad.No_Obeso:
                    retorno = 25;
                    break;
                case EGradoObesidad.Grado_1:
                    retorno = 50;
                    break;
                case EGradoObesidad.Grado_2:
                    retorno = 75;
                    break;
                case EGradoObesidad.Grado_3:
                    retorno = 100;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Inicia las barras de progreso y las carga dinamicamente
        /// </summary>
        private void IniciarBarras()
        {
            this.progressBarComposicion.Value = 0;
            this.progressBarGradoObesidad.Value = 0;
            this.progressBarIMC.Value = 0;

            this.cts = new CancellationTokenSource();
            CancellationToken ct = this.cts.Token;

            Task composicion = new Task(() => IniciarBarraComposicion(this.progressBarComposicion), ct);
            composicion.Start();
            hilosBarras.Add(composicion);

            Task obesidad = new Task(() => IniciarBarra(this.progressBarGradoObesidad, this.CalcularProgressBarGradoObesidad()), ct);
            obesidad.Start();
            hilosBarras.Add(obesidad);

            Task imc = new Task(() => IniciarBarra(this.progressBarIMC, (int)this.contacto.Imc), ct);
            imc.Start();
            hilosBarras.Add(imc);
        }

        /// <summary>
        /// Inicia el proceso de una barra de progreso e incrementa su valor
        /// </summary>
        /// <param name="barraProgreso">barra de progreso a iniciar</param>
        /// <param name="maximo">valor maximo de carga</param>
        private void IniciarBarra(ProgressBar barraProgreso, int maximo)
        {
            while (barraProgreso.Value < maximo && !cts.IsCancellationRequested)
            {
                this.IncrementarBarraProgreso(barraProgreso);
            }
        }

        /// <summary>
        /// Inicia el proceso de una barra de progreso, incrementa su valor y cambia el mensaje de observacion
        /// </summary>
        /// <param name="barraProgreso">barra de progreso a iniciar</param>
        private void IniciarBarraComposicion(ProgressBar barraProgreso)
        {
            int maximo = this.CalcularProgressBarComposicion();
            while (barraProgreso.Value < maximo && !cts.IsCancellationRequested)
            {
                this.IncrementarBarraProgreso(barraProgreso);
                this.MostrarMensajeObservacion(barraProgreso);
            }
        }

        /// <summary>
        /// Incrementa el valor de una barra de progreso
        /// </summary>
        /// <param name="barraProgreso">barra de progreso a incrementar</param>
        private void IncrementarBarraProgreso(ProgressBar barraProgreso)
        {
            if (this.InvokeRequired)
            {
                Action<ProgressBar> delegado = IncrementarBarraProgreso;
                object[] parametros = new object[] { barraProgreso };
                this.Invoke(delegado, parametros);
            }
            else
            {
                barraProgreso.Increment(1);
            }
        }

        /// <summary>
        /// Finaliza el proceso de las barras de progreso
        /// </summary>
        private void FinalizarBarras()
        {
            this.cts.Cancel();
        }

        private void FrmFicha_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FinalizarBarras();
        }
    }
}





