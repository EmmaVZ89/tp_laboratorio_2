using System;
using System.Text;

namespace Entidades
{
    public class Persona
    {
        protected string nombre;
        protected int edad;
        protected string sexo;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public int Edad
        {
            get
            {
                return this.edad;
            }
        }
        public string Sexo
        {
            get
            {
                return this.sexo;
            }
        }

        public Persona(string nombre, int edad, string sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Edad: {this.edad} años");
            sb.AppendLine($"Sexo: {this.sexo}");

            return sb.ToString();
        }
    }
}
