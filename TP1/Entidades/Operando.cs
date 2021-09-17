using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {

        #region atributos
        private double numero;
        #endregion

        #region propiedades
        public string Numero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }
        #endregion

        #region metodos
        public string BinarioDecimal (string binario)
        {
            string retorno = "Valor inválido";
            int largoCadena;
            int numeroDecimal;
            int potencia;

            if (this.EsBinario(binario))
            {
                largoCadena = binario.Length;
                numeroDecimal = 0;
                potencia = 0;
                for (int i = largoCadena - 1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        numeroDecimal = (int)(numeroDecimal + Math.Pow(2, potencia));
                    }
                    potencia++;
                }
                retorno = numeroDecimal.ToString();
            }

            return retorno;
        }

        public string DecimalBinario (double numero)
        {
            string retorno = "";
            numero = (int)numero;

            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }
                    numero = (int)(numero / 2);
                }
            }
            else
            {
                if(numero == 0)
                {
                    retorno = "0";
                }
                else
                {
                    retorno = "Valor inválido";
                }
            }

            return retorno;
        }

        public string DecimalBinario (string numero)
        {
            double numeroRetorno;
            string retorno = "Valor Invalido";

            if(Double.TryParse(numero, out numeroRetorno))
            {
                retorno = this.DecimalBinario(numeroRetorno);
            }

            return retorno;
        }

        private bool EsBinario (string binario)
        {
            bool retorno = true;

            foreach (char letra in binario)
            {
                if(letra != '0' && letra != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        private double ValidarOperando (string strNumero)
        {
            double retorno;

            if (Double.TryParse(strNumero, out retorno) == false)
            {
                retorno = 0;
            }

            return retorno;
        }
        #endregion

        #region constructores
        public Operando() : this(0)
        {}

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region sobrecarga de operadores
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator / (Operando n1, Operando n2)
        {
            double resultado;

            if(n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion

    }
}