using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface IArchivo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
        void GuardarArchivo(string ruta, T contenido);
        void GuardarArchivoComo(string ruta, T contenido);
        T LeerArchivo(string ruta);
    }
}
