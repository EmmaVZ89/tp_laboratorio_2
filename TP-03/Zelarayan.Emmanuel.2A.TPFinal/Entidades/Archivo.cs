using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Archivo
    {
        protected abstract string Extension { get; }

        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) == this.Extension)
            {
                return true;
            }
            else
            {
                throw new ExtensionIncorrectaException($"El archivo no tiene la extension {this.Extension}");
            }
        }

        public bool ValidarSiExisteElArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                return true;
            }
            else
            {
                throw new ExtensionIncorrectaException("El archivo no se encontro.");
            }
        }
    }
}
