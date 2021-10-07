using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Suv deriva de la clase Vehiculo
    /// </summary>
    public class Suv : Vehiculo // se agrego : Vehiculo 
    {
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Permite que se instancien elementos del tipo Suv
        /// </summary>
        /// <param name="marca">marca de un Vehiculo, tipo EMarca</param>
        /// <param name="chasis">chasis de un Vehiculo, tipo String</param>
        /// <param name="color">color de un Vehiculo, tipo ConsoleColor</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Publica todos los datos de un elemento del tipo Suv
        /// </summary>
        /// <returns>retorna todos los datos de un elemento tipo Suv</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.Append(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); // convierto el sb en una string
        }
    }
}
