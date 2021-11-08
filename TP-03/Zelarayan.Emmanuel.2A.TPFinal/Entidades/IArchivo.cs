using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivo<T>
    {
        void GuardarArchivo(string ruta, T contenido);
        void GuardarArchivoComo(string ruta, T contenido);
        T LeerArchivo(string ruta);
    }
}
