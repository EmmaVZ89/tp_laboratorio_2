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
            set
            {
                this.nombre = value;
            }
        }
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

        public Persona()
        { }
        public Persona(string nombre, int edad, string sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

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
