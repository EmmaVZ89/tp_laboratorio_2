using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// La clase Sedan deriva de la clase Vehiculo
    /// </summary>
    public class Sedan : Vehiculo
    {
        public enum ETipo 
        {
            CuatroPuertas,
            CincoPuertas
        }

        private ETipo tipo; // agregue modificador private

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas. Permite que se instancien elementos del tipo Sedan
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas) // utilizo la sobrecarga y le asigno un valor por defecto al tipo
        {
        }

        /// <summary>
        /// Permite que se instancien elementos del tipo Sedan 
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Publica todos los datos de un elemento del tipo Sedan
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.Append($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); // convierto el sb en una string
        }
    }
}
