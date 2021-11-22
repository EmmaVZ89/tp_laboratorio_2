using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase Persona
    /// </summary>
    public class Persona
    {
        protected string nombre;
        protected int edad;
        protected string sexo;

        /// <summary>
        /// Propiedad de lectura y escritura del campo nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo edad
        /// </summary>
        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        /// <summary>
        /// Propidad de lectura y escritura del campo Sexo
        /// </summary>
        public string Sexo
        {
            get
            {
                return this.sexo;
            }
            set
            {
                this.sexo = value;
            }
        }

        /// <summary>
        /// Constructor por defecto de una Persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor de una Persona
        /// </summary>
        /// <param name="nombre"> el nombre de una Persona</param>
        /// <param name="edad"> la edad de una Persona</param>
        /// <param name="sexo"> el sexo de una Persona</param>
        public Persona(string nombre, int edad, string sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        /// <summary>
        /// Sobrescritura del metodo ToString para que muestra todos los datos de una Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.nombre} - ");
            sb.Append($"{this.edad} años - ");
            sb.Append($"{this.sexo} ");

            return sb.ToString();
        }
    }
}
