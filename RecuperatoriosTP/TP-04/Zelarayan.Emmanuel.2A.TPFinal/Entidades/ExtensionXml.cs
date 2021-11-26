using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase ExtensionXml deriva de Clase Archivo e implementa Interface IArchivo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExtensionXml<T> : Archivo, IArchivo<T> where T : class
    {
        /// <summary>
        /// Propiedad de solo lectura del campo extension
        /// </summary>
        protected override string Extension
        {
            get
            {
                return ".xml";
            }
        }

        /// <summary>
        /// Guarda informacion en un archivo XML
        /// </summary>
        /// <param name="ruta">ruta del archivo</param>
        /// <param name="contenido">contenido a guardar</param>
        public void GuardarArchivo(string ruta, T contenido)
        {
            if (this.ValidarExtension(ruta))
            {
                this.Serializar(ruta, contenido);
            }
        }

        /// <summary>
        /// Guarda informacion en un archivo XML
        /// </summary>
        /// <param name="ruta">ruta del archivo</param>
        /// <param name="contenido">contenido a guardar</param>
        public void GuardarArchivoComo(string ruta, T contenido)
        {
            if (this.ValidarExtension(ruta))
            {
                this.Serializar(ruta, contenido);
            }

        }

        /// <summary>
        /// Leer un archivo XLM
        /// </summary>
        /// <param name="ruta">ruta del archivo a leer</param>
        /// <returns>retorna el contenido del archivo</returns>
        public T LeerArchivo(string ruta)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSelializer = new XmlSerializer(typeof(T));
                    T contenido = xmlSelializer.Deserialize(streamReader) as T;

                    return contenido;
                }
            }

            return null;
        }

        /// <summary>
        /// Serializar informacion en un archivo XLM
        /// </summary>
        /// <param name="ruta">ruta del donde se guardara la informacion</param>
        /// <param name="contenido"> contenido a serializar</param>
        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSelializer = new XmlSerializer(typeof(T));
                xmlSelializer.Serialize(streamWriter, contenido);
            }
        }
    }

}
