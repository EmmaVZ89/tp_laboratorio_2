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

namespace AgendaSaludable
{
    public partial class FrmAltaModificacion : Form
    {
        private Contacto nuevoContacto;
        bool flagEsAlta;

        /// <summary>
        /// Constructor de un FrmAltaModificacion por defecto
        /// </summary>
        public FrmAltaModificacion()
        {
            InitializeComponent();
            this.flagEsAlta = true;
        }

        /// <summary>
        /// Contructor de un FrmAltaModificacion con parametros
        /// </summary>
        /// <param name="contacto">Contacto a modificar</param>
        public FrmAltaModificacion(Contacto contacto):this()
        {
            this.nuevoContacto = contacto;
            this.flagEsAlta = false;
        }

        /// <summary>
        /// Propiedad de solo lectura del campo nuevoContacto
        /// </summary>
        public Contacto NuevoContacto
        {
            get
            {
                return this.nuevoContacto;
            }
        }

        /// <summary>
        /// Evento FrmAltaContacto_Load, encargado de cargar todas las caracteristicas predefinidas
        /// y determinar si se trata de un alta o modificacion de un Contacto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaContacto_Load(object sender, EventArgs e)
        {
            this.cmbSexo.Items.Add("Hombre");
            this.cmbSexo.Items.Add("Mujer");
            this.cmbSexo.SelectedIndex = 0;
            this.toolTipAyuda.SetToolTip(this.lblNombre, "Ingrese su nombre: ej. Juan");
            this.toolTipAyuda.SetToolTip(this.lblEdad, "Ingrese su Edad: ej. 25");
            this.toolTipAyuda.SetToolTip(this.lblTelefono, "Ingrese su telefono: ej. 1559253641");
            this.toolTipAyuda.SetToolTip(this.lblPeso, "Ingrese su Peso: ej. 75,500");
            this.toolTipAyuda.SetToolTip(this.lblAltura, "Ingrese su Altura: ej. 1,80");

            if(this.flagEsAlta)
            {
                this.Text = "Alta de Contacto";
                this.lblTitulo.Text = "Alta Contacto";
                this.btnAceptar.Text = "Guardar Contacto";
            }
            else
            {
                this.Text = "Modificacion de Contacto";
                this.lblTitulo.Text = "Modificar Contacto";
                this.btnAceptar.Text = "Modificar Contacto";

                this.txtNombre.Text = nuevoContacto.Nombre;
                this.txtEdad.Text = nuevoContacto.Edad.ToString();
                this.txtTelefono.Text = nuevoContacto.Telefono.ToString();
                this.txtPeso.Text = nuevoContacto.Peso.ToString();
                this.txtAltura.Text = nuevoContacto.Altura.ToString();
            }
        }

        /// <summary>
        /// Evento btnAceptar_Click, encargado de enviar el nuevo usuario o usuario modificado al formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int edad;
            int telefono;
            double peso;
            double altura;

            if (!(String.IsNullOrWhiteSpace(this.txtNombre.Text)) && int.TryParse(this.txtEdad.Text, out edad) && int.TryParse(this.txtTelefono.Text, out telefono) &&
                Double.TryParse(this.txtPeso.Text, out peso) && Double.TryParse(this.txtAltura.Text, out altura))
            {
                if (this.flagEsAlta)
                {
                    this.nuevoContacto = new Contacto(this.txtNombre.Text, edad, this.cmbSexo.SelectedItem.ToString(),
                    telefono, peso, altura);
                }
                else
                {
                    this.nuevoContacto.Nombre = this.txtNombre.Text;
                    this.nuevoContacto.Sexo = this.cmbSexo.SelectedItem.ToString();
                    this.nuevoContacto.Edad = edad;
                    this.nuevoContacto.Telefono = telefono;
                    this.nuevoContacto.Peso = peso;
                    this.nuevoContacto.Altura = altura;
                    this.nuevoContacto.Imc = Math.Round(this.nuevoContacto.CalcularIMC());
                    this.nuevoContacto.ComposicionCorporal = this.nuevoContacto.DeterminarComposicion(this.nuevoContacto.Imc);
                    this.nuevoContacto.GradoObesidad = this.nuevoContacto.DeterminarGradoObesidad(this.nuevoContacto.ComposicionCorporal);
                }

                if (this.nuevoContacto != null)
                {
                    this.DialogResult = DialogResult.OK;
                }

            }
            else
            {
                this.MostrarMensajeDeDatosIncompletos();
            }
        }

        /// <summary>
        /// Evento btnCancelar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Evento txtNombre_KeyPress, encargado de prohibir el ingreso de numeros en un textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PermitirSoloLetras(e);
        }

        /// <summary>
        /// Evento txtEdad_KeyPress, encargado de prohibir el ingreso de letras en un textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PermitirSoloNumeros(e);
        }

        /// <summary>
        /// Evento txtTelefono_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PermitirSoloNumeros(e);
        }

        /// <summary>
        /// Evento txtPeso_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PermitirSoloNumerosConComa(e);
        }

        /// <summary>
        /// Evento txtAltura_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PermitirSoloNumerosConComa(e);
        }

        /// <summary>
        /// Permite solo el ingreso de numeros
        /// </summary>
        /// <param name="e"></param>
        private void PermitirSoloNumeros(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo numeros, y en caso de que se necesite, tambien comas
        /// </summary>
        /// <param name="e"></param>
        private void PermitirSoloNumerosConComa(KeyPressEventArgs e)
        {
            if (e.KeyChar == 44)
            {
                e.Handled = false;
            }
            else if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                    (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo el ingreso de letras
        /// </summary>
        /// <param name="e"></param>
        private void PermitirSoloLetras(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) ||
                (e.KeyChar >= 91 && e.KeyChar <= 96) ||
                (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Muestras un mensaje cuando los datos del Contacto son incorrectos
        /// </summary>
        private void MostrarMensajeDeDatosIncompletos()
        {
            MessageBox.Show("Datos incompletos y/o incorrectos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
