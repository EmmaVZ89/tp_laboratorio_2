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

        /// <summary>
        /// convierte un numero binario en uno decimal
        /// </summary>
        /// <param name="binario"> cadena que contiene el numero binario</param>
        /// <returns> si se pudo convertir el numero binario en decimal se lo retorna, sino se devuelte "Valor invalido" </returns>
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

        /// <summary>
        /// convierte un numero decimal en uno binario
        /// </summary>
        /// <param name="numero"> numero decimal </param>
        /// <returns> retorna el numero binario si se pudo hacer la conversion, sino retorna "Valor invalido" </returns>
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

        /// <summary>
        /// convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero"> cadena con un numero decimal</param>
        /// <returns> si el numero pudo ser convertido a binario lo retorna, sino retorna "Valor invalido" </returns>
        public string DecimalBinario (string numero)
        {
            double numeroRetorno;
            string retorno = "Valor inválido";

            if(Double.TryParse(numero, out numeroRetorno))
            {
                retorno = this.DecimalBinario(numeroRetorno);
            }

            return retorno;
        }

        /// <summary>
        /// determina si la cadena pasada contiene un numero binario
        /// </summary>
        /// <param name="binario"> cadena con un numero</param>
        /// <returns> retorna true si el numero es binario, sino retorna false </returns>
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

        /// <summary>
        /// valida si la cadena pasada es numerica
        /// </summary>
        /// <param name="strNumero"> cadena numerica</param>
        /// <returns> si la cadena es numerica retorna el numero, sino retorna 0 </returns>
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

        /// <summary>
        /// realiza la resta de dos objetos "Operando", restando su atributo "numero"
        /// </summary>
        /// <param name="n1"> primer objeto Operando </param>
        /// <param name="n2"> segundo objeto Operando </param>
        /// <returns> retorna el resultado </returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// realiza el producto de dos objetos "Operando", tomando los atributos "numero"
        /// </summary>
        /// <param name="n1"> primer objeto Operando </param>
        /// <param name="n2"> segundo objeto Operando </param>
        /// <returns> retorna el resultado </returns>
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// realiza la division de dos objetos "Operando", dividiendo sus atributos "numero"
        /// </summary>
        /// <param name="n1"> primer objeto Operando </param>
        /// <param name="n2"> segundo objeto Operando </param>
        /// <returns> retorna el resultado si el segungo operando es diferente de 0, sino retorna double.MinValue </returns>
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

        /// <summary>
        /// realiza la suma de dos objetos "Operando", sumando sus atributo "numero"
        /// </summary>
        /// <param name="n1"> primer objeto Operando </param>
        /// <param name="n2"> segundo objeto Operando </param>
        /// <returns> retorna el resultado </returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion

    }
}