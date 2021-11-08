using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExtensionIncorrectaException : Exception
    {
        public ExtensionIncorrectaException(string message) : base(message)
        {
        }
    }
}
