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
        /// <param name="marca">marca de un Vehiculo, tipo EMarca</param>
        /// <param name="chasis">chasis de un Vehiculo, tipo String</param>
        /// <param name="color">color de un Vehiculo, tipo ConsoleColor</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas) // utilizo la sobrecarga y le asigno un valor por defecto al tipo
        {
        }

        /// <summary>
        /// Permite que se instancien elementos del tipo Sedan con el dato tipo
        /// </summary>
        /// <param name="marca">marca de un Vehiculo, tipo EMarca</param>
        /// <param name="chasis">chasis de un Vehiculo, tipo String</param>
        /// <param name="color">color de un Vehiculo, tipo ConsoleColor</param>
        /// <param name="tipo">tipo (cuatroPuertar o cincoPuertas), del tipo ETipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Publica todos los datos de un elemento del tipo Sedan
        /// </summary>
        /// <returns>retorna todos los datos de un elemento tipo Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.Append(base.Mostrar()); // se reutiliza el metodo Mostrar de base
            sb.Append($"TIPO : {this.tipo}\n\n");
            sb.AppendLine("---------------------");

            return sb.ToString(); // convierto el sb en una string
        }
    }
}
