using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExtensionTxt : Archivo, IArchivo<string>
    {
        protected override string Extension
        {
            get
            {
                return ".txt";
            }
        }

        public void GuardarArchivo(string ruta, string contenido)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                this.EscribirArchivo(ruta, contenido);
            }
        }

        public void GuardarArchivoComo(string ruta, string contenido)
        {
            if (this.ValidarExtension(ruta))
            {
                this.EscribirArchivo(ruta, contenido);
            }
        }

        public string LeerArchivo(string ruta)
        {
            if (this.ValidarSiExisteElArchivo(ruta) && this.ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string contenido = streamReader.ReadLine();
                    return contenido;
                }
            }

            return null;
        }

        private void EscribirArchivo(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.Write(contenido);
            }
        }

    }
}
