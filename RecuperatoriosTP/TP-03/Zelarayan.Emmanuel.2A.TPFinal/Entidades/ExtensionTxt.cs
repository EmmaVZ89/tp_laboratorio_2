using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase ExtensionTxt, deriva de la clase Archivo e implementa la interface IArchivo
    /// </summary>
    public class ExtensionTxt : Archivo, IArchivo<string>
    {
        /// <summary>
        /// Propiedad de solo lectura del campo extension
        /// </summary>
        protected override string Extension
        {
            get
            {
                return ".txt";
            }
        }

        /// <summary>
        /// Guarda informacion en un archivo txt
        /// </summary>
        /// <param name="ruta">ruta del archivo</param>
        /// <param name="contenido">contenido a guardar</param>
        public void GuardarArchivo(string ruta, string contenido)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                this.Escribir(ruta, contenido);
            }
        }

        /// <summary>
        /// Guarda informacion en un archivo txt
        /// </summary>
        /// <param name="ruta">ruta del archivo</param>
        /// <param name="contenido">contenido a guardar</param>
        public void GuardarArchivoComo(string ruta, string contenido)
        {
            if (this.ValidarExtension(ruta))
            {
                this.Escribir(ruta, contenido);
            }
        }

        /// <summary>
        /// Leer un archivo txt
        /// </summary>
        /// <param name="ruta">ruta del archivo a leer</param>
        /// <returns>retorna el contenido del archivo</returns>
        public string LeerArchivo(string ruta)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string contenido = streamReader.ReadToEnd();
                    return contenido;
                }
            }

            return null;
        }

        /// <summary>
        /// Escribe informacion en un archivo txt
        /// </summary>
        /// <param name="ruta">ruta del donde se guardara la informacion</param>
        /// <param name="contenido"> contenido a escribir</param>
        private void Escribir(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.Write(contenido);
            }
        }

    }
}
