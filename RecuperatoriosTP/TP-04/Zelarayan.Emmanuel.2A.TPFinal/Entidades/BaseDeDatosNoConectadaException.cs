using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BaseDeDatosNoConectadaException : Exception
    {
        /// <summary>
        /// Constructor de una BaseDeDatosNoConectadaException
        /// </summary>
        /// <param name="message">mensaje a mostrar</param>
        public BaseDeDatosNoConectadaException(string message) : base(message)
        {
        }
    }
}
