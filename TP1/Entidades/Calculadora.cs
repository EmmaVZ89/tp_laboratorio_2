using System;

namespace Entidades
{
    public static class Calculadora
    {
        #region metodos
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
