using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Contacto : Persona, ICalculos
    {
        protected int telefono;
        protected double peso;
        protected double altura;
        protected double imc;
        protected EComposicionCorporal composicionCorporal;
        protected EGradoObesidad gradoObesidad;

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
        public double Imc
        {
            get
            {
                return this.imc;
            } 
        }
        public EComposicionCorporal ComposicionCorporal
        {
            get
            {
                return this.composicionCorporal;
            }
        }
        public EGradoObesidad GradoObesidad
        {
            get
            {
                return this.gradoObesidad;
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
            this.imc = Math.Round(this.CalcularIMC(), 2);
            this.composicionCorporal = this.DeterminarComposicion(this.imc);
            this.gradoObesidad = this.DeterminarGradoObesidad(this.composicionCorporal);
        }

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
            sb.AppendLine($"IMC: {this.imc}");
            sb.AppendLine($"Composision corporal: {this.composicionCorporal}");
            sb.AppendLine($"Grado de obesidad: {this.gradoObesidad}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Contacto)
            {
                retorno = (Contacto)obj == this;
            }
            return retorno;
        }

        public double CalcularIMC()
        {
            double retornoImc;
            retornoImc = this.peso / Math.Pow(this.altura, 2);
            return retornoImc;
        }

        public EComposicionCorporal DeterminarComposicion(double imc)
        {
            EComposicionCorporal composicion;
            
            if(imc < 18.5)
            {
                composicion = EComposicionCorporal.Bajo_peso;
            }
            else if(imc >= 18.5 && imc <= 24.9)
            {
                composicion = EComposicionCorporal.Normal;
            }
            else if(imc >= 25 && imc <= 29.9)
            {
                composicion = EComposicionCorporal.Sobrepeso;
            }
            else
            {
                composicion = EComposicionCorporal.Obesidad;
            }

            return composicion;
        }

        public EGradoObesidad DeterminarGradoObesidad(EComposicionCorporal composicion)
        {
            EGradoObesidad gradoObesidad = EGradoObesidad.No_Obeso;
            if(composicion == EComposicionCorporal.Obesidad)
            {
                if (this.imc >= 30 && this.imc <= 34.9)
                {
                    gradoObesidad = EGradoObesidad.Grado_1;
                }
                else if(this.imc >= 35 && this.imc <= 39.9)
                {
                    gradoObesidad = EGradoObesidad.Grado_2;
                }
                else
                {
                    gradoObesidad = EGradoObesidad.Grado_3;
                }
            }
            return gradoObesidad;
        }
    }
}
