using System;

namespace Entidades
{

    public static class Calculadora
    {

        #region metodos

        /// <summary>
        /// recibe dos objetos de tipo Operando y el operador, realiza la cuenta y devuelve el resultado
        /// </summary>
        /// <param name="num1">primer operando</param>
        /// <param name="num2">segundo operando</param>
        /// <param name="operador">operador</param>
        /// <returns>retorna el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operacion = Calculadora.ValidarOperador(operador);
            double resultado = 0;

            switch (operacion)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// verifica si el operador recibido es valido
        /// </summary>
        /// <param name="operador"> operador recibido </param>
        /// <returns> si el operador es valido lo retorna, de lo contrario retorna el operador + </returns>
        private static char ValidarOperador(char operador)
        {
            char retorno;

            switch (operador)
            {
                case '+':
                    retorno = '+';
                    break;
                case '-':
                    retorno = '-';
                    break;
                case '/':
                    retorno = '/';
                    break;
                case '*':
                    retorno = '*';
                    break;
                default:
                    retorno = '+';
                    break;
            }
            return retorno;
        }

        #endregion

    }
}
