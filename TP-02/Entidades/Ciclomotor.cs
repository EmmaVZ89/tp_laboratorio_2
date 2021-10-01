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
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Publica todos los datos de un elemento del tipo Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar() // agruegue modificador public
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.AppendLine("---------------------");

            return sb.ToString();// convierto el sb en una string
        }
    }
    }
}
