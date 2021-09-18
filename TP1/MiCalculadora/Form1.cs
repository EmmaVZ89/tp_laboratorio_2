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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

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

        private void cmbOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

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
                DialogResult rta = MessageBox.Show("Debe ingresar caracteres numericos", "Atención",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Limpiar();
            }
        }

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

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

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