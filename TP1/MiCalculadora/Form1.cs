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

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

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
            string num1;
            string num2;
            string operacion;
            string historial = "";
            
            num1 = this.txtNumero1.Text;
            num2 = this.txtNumero2.Text;
            operacion = this.cmbOperador.SelectedItem.ToString();

            resultado = (FormCalculadora.Operar(num1, num2, operacion)).ToString();

            this.lblResultado.Text = resultado;

            if (!String.IsNullOrEmpty(operacion))
            {
                historial = num1 + " " + operacion + " " + num2 + " = " + resultado;
                lstOperaciones.Items.Add(historial);
            }

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado;
            string numDecimal;

            resultado = new Operando();
            numDecimal = this.lblResultado.Text;

            this.lblResultado.Text = resultado.DecimalBinario(numDecimal);

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado;
            string numDecimal;

            resultado = new Operando();
            numDecimal = this.lblResultado.Text;

            this.lblResultado.Text = resultado.BinarioDecimal(numDecimal);

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