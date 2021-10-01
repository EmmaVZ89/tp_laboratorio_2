using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo // cambie modificador sealed por abstract
    {
        public enum EMarca // agregue modificador public 
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }

        public enum ETamanio // agregue modificador public 
        {
            Chico,
            Mediano,
            Grande
        }
        
        private EMarca marca; // agregue modificador private
        private string chasis; // agregue modificador private
        private ConsoleColor color; // agregue modificador private


        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; } // agregue modificador protected y borre set;

        /// <summary>
        /// Permite que se instancien elementos del tipo Vehiculo, en este caso solo se podran instanciar clases derivadas
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        virtual public string Mostrar() // agregue modificador virtual y public
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca.ToString()}");
            sb.AppendLine($"COLOR : {this.color.ToString()}");
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendLine($"TAMAÑO : {this.Tamanio.ToString()}"); // agregue la propiedad Tamanio para luego reutilizar el codigo

            return sb.ToString();
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo si se castea explicitamente a string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p) // cambio de modificador private por public
        {
            // elimine todo el codigo y reutilice el metodo Mostrar
            return p.Mostrar();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            // elimine el codigo completo y use una variable intermedia para el retorno
            bool retorno = false;

            if(String.Compare(v1.chasis, v2.chasis) == 0) 
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2); // reutilizacion del operador == negando el retorno.
        }

    }
}
