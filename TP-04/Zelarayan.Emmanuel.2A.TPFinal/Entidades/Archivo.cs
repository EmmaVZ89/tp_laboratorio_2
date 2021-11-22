using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Archivo
    /// </summary>
    public abstract class Archivo
    {
        /// <summary>
        /// Propiedad de solo lectura
        /// </summary>
        protected abstract string Extension { get; }

        /// <summary>
        /// Valida que la extension de un archivo sea la correcta
        /// </summary>
        /// <param name="ruta">ruta del archivo</param>
        /// <returns>retorna true si es correcta, sino lanza ExtensionIncorrectaException</returns>
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

        /// <summary>
        /// Valida si existe o no un archivo
        /// </summary>
        /// <param name="ruta">ruta de un archivo</param>
        /// <returns>retorna true si el archivo existe, sino lanza ExtensionIncorrectaException</returns>
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
