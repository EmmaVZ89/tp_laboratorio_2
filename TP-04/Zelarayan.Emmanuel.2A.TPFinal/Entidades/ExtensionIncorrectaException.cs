using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase ExtensionIncorrectaException, deriva de clase Exception
    /// </summary>
    public class ExtensionIncorrectaException : Exception
    {
        /// <summary>
        /// Constructor de una ExtensionIncorrectaException
        /// </summary>
        /// <param name="message">mensaje a mostrar</param>
        public ExtensionIncorrectaException(string message) : base(message)
        {
        }
    }
}
