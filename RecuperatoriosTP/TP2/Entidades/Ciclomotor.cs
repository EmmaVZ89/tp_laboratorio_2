using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Ciclomotor deriva de la clase Vehiculo
    /// </summary>
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio // agregue modificador override y el tipo de retorno ETamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Permite que se instancien elementos del tipo Ciclomotor
        /// </summary>
        /// <param name="marca">marca de un Vehiculo, tipo EMarca</param>
        /// <param name="chasis">chasis de un Vehiculo, tipo String</param>
        /// <param name="color">color de un Vehiculo, tipo ConsoleColor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Publica todos los datos de un elemento del tipo Ciclomotor
        /// </summary>
        /// <returns>retorna todos los datos de un elemento tipo Ciclomotor</returns>
        public override sealed string Mostrar() // agruegue modificador public
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.Append(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();// convierto el sb en una string
        }
    }
}
