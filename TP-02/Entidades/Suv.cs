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
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
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
        /// Publica todos los datos del SUV
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.AppendLine("TAMAÑO : " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); // convierto el sb en una string
        }
    }
}
