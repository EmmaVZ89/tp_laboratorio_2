using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class ExtensionXml<T> : Archivo, IArchivo<T> where T : class
    {
        protected override string Extension
        {
            get
            {
                return ".xml";
            }
        }

        public void GuardarArchivo(string ruta, T contenido)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                this.Serializar(ruta, contenido);
            }
        }

        public void GuardarArchivoComo(string ruta, T contenido)
        {
            if (this.ValidarExtension(ruta))
            {
                this.Serializar(ruta, contenido);
            }

        }

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
