using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Contacto : Persona
    {
        private int telefono;
        private double peso;
        private double altura;

        public int Telefono
        {
            get
            {
                return this.telefono;
            }
        }
        public double Peso
        {
            get
            {
                return this.peso;
            }
        }
        public double Altura
        {
            get
            {
                return this.altura;
            }
        }

        public Contacto(string nombre, int edad, string sexo)
                        : base(nombre, edad, sexo)
        {
        }

        public Contacto(string nombre, int edad, string sexo,
                        int telefono, double peso, double altura)
                        : this(nombre, edad, sexo)
        {
            this.telefono = telefono;
            this.peso = peso;
            this.altura = altura;
        }

        //public static double CalcularIMC(double peso, double altura)
        //{
        //    double retornoImc;

        //    retornoImc = peso / Math.Pow(altura, 2);

        //    return retornoImc;
        //}

        public static bool operator == (Contacto c1, Contacto c2)
        {
            bool retorno = false;

            if(c1.nombre == c2.nombre && c1.telefono == c2.telefono)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Contacto c1, Contacto c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($"Telefono: {this.telefono}");
            sb.AppendLine($"Peso: {this.peso} Kg");
            sb.AppendLine($"Altura: {this.altura} Mt");

            return sb.ToString();
        }


    }
}
