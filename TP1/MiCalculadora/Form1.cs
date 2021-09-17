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
            string num1;
            string num2;
            string operacion;
            
            num1 = this.txtNumero1.Text;
            num2 = this.txtNumero2.Text;
            operacion = this.cmbOperador.SelectedItem.ToString();

            resultado = (FormCalculadora.Operar(num1, num2, operacion)).ToString();

            this.lblResultado.Text = resultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1;
            Operando num2;
            double resultado = 0;

            if( !String.IsNullOrEmpty(operador))
            {
                num1 = new Operando(numero1);
                num2 = new Operando(numero2);
                resultado = Calculadora.Operar(num1, num2, operador[0]);
            }

            return resultado;
        }
    }
}