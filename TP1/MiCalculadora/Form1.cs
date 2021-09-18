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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// cierra el formulario, antes pidiendo al usuario una confirmacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Atención",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        /// <summary>
        /// evita que el usuario escriba en el Combo Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// cierra el formulario, antes pidiendo al usuario una confirmacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Atención",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                this.Close();
            }

        }

        /// <summary>
        /// elimina el contenido de los controles txtNumero1.Text, txtNumero2.Text, cmbOperador.Text y lblResultado.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// realiza las operaciones matematicas, segun lo que el usuario halla ingresado en los controles
        /// txtNumero1.Text, txtNumero2.Text y cmbOperador.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado;
            double num1;
            double num2;
            string operacion;
            string historial = "";
            

            if(Double.TryParse(this.txtNumero1.Text, out num1) && Double.TryParse(this.txtNumero2.Text, out num2))
            {
                operacion = this.cmbOperador.SelectedItem.ToString();
                resultado = (FormCalculadora.Operar(num1.ToString(), num2.ToString(), operacion)).ToString();

                this.lblResultado.Text = resultado;

                if (!String.IsNullOrEmpty(operacion))
                {
                    historial = num1 + " " + operacion + " " + num2 + " = " + resultado;
                    lstOperaciones.Items.Add(historial);
                }
            }
            else
            {
                DialogResult rta = MessageBox.Show("Se deben ingresar números", "Atención",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Limpiar();
            }
        }

        /// <summary>
        /// convierte el resultado de una operacion en binario, en caso de que sea posible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado;
            string strNumero;
            double decNumero;

            if(Double.TryParse(this.lblResultado.Text, out decNumero))
            {
                resultado = new Operando();
                strNumero = this.lblResultado.Text;
                if (decNumero >= 0)
                {
                    this.lblResultado.Text = resultado.DecimalBinario(strNumero);
                }
                else
                {
                    DialogResult rta = MessageBox.Show(resultado.DecimalBinario(strNumero), "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// convierte el resultado de una operacion en decimal, en caso de que sea posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado;
            string strNumero;
            string retorno;
            double aux;

            resultado = new Operando();
            strNumero = this.lblResultado.Text;
            retorno = resultado.BinarioDecimal(strNumero);

            if (Double.TryParse(retorno, out aux))
            {
                this.lblResultado.Text = retorno;
            }
            else
            {
                DialogResult rta = MessageBox.Show(retorno, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// elimina el contenido de los controles txtNumero1.Text, txtNumero2.Text, cmbOperador.Text y lblResultado.Text
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// realiza las operaciones matematicas, segun lo que el usuario halla ingresado en los controles
        /// </summary>
        /// <param name="numero1"> primer cadena con un numero</param>
        /// <param name="numero2"> segunda cadena con un numero</param>
        /// <param name="operador">cadena con el operando</param>
        /// <returns> si se puedo realizar la operacion retorna el resultado, sino retorna 0</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1;
            Operando num2;
            double resultado = 0;

            if( !String.IsNullOrEmpty(operador))
            {
                num1 = new Operando(numero1);
                num2 = new Operando(numero2);
                resultado = Calculadora.Operar(num1, num2, char.Parse(operador));
            }

            return resultado;
        }

    }
}