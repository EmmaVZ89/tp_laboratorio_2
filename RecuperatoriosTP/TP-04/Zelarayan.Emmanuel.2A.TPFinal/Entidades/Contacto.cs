using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Contacto, derivada de Persona.
    /// </summary>
    public class Contacto : Persona, ICalculos
    {
        protected int telefono;
        protected double peso;
        protected double altura;
        protected double imc;
        protected EComposicionCorporal composicionCorporal;
        protected EGradoObesidad gradoObesidad;

        /// <summary>
        /// Propiedad de lectura y escritura del campo telefono.
        /// </summary>
        public int Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo peso
        /// </summary>
        public double Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                this.peso = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo altura
        /// </summary>
        public double Altura
        {
            get
            {
                return this.altura;
            }
            set
            {
                this.altura = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo imc
        /// </summary>
        public double Imc
        {
            get
            {
                return this.imc;
            } 
            set
            {
                this.imc = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo composicionCorporal
        /// </summary>
        public EComposicionCorporal ComposicionCorporal
        {
            get
            {
                return this.composicionCorporal;
            }
            set
            {
                this.composicionCorporal = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo gradoObesidad
        /// </summary>
        public EGradoObesidad GradoObesidad
        {
            get
            {
                return this.gradoObesidad;
            }
            set
            {
                this.gradoObesidad = value;
            }
        }

        /// <summary>
        /// Constructor por defecto de un Contacto
        /// </summary>
        public Contacto()
        {
        }

        /// <summary>
        /// Constructor de un Contacto
        /// </summary>
        /// <param name="nombre">nombre de un Contacto</param>
        /// <param name="edad">edad de un Contacto</param>
        /// <param name="sexo">sexo de un Contacto</param>
        public Contacto(string nombre, int edad, string sexo)
                        : base(nombre, edad, sexo)
        {
        }

        /// <summary>
        /// Constructor de un Contacto
        /// </summary>
        /// <param name="nombre">nombre de un Contacto</param>
        /// <param name="edad">edad de un Contacto</param>
        /// <param name="sexo">sexo de un Contacto</param>
        /// <param name="telefono">telefono de un Contacto</param>
        /// <param name="peso">peso de un Contacto</param>
        /// <param name="altura">altura de un Contacto</param>
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

        /// <summary>
        /// Sobrescritura del operador ==
        /// </summary>
        /// <param name="c1">primer Contacto</param>
        /// <param name="c2">segundo Contacto</param>
        /// <returns>retorno true si los contactos son iguales, sino retorno false</returns>
        public static bool operator == (Contacto c1, Contacto c2)
        {
            bool retorno = false;
            if(c1 is not null && c2 is not null)
            {
                if (c1.telefono == c2.telefono)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrescritura del operador !=
        /// </summary>
        /// <param name="c1">primer Contacto</param>
        /// <param name="c2">segundo Contacto</param>
        /// <returns>retorno true si los contactos son diferentes, sino retorno false</returns>
        public static bool operator !=(Contacto c1, Contacto c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Sobrescritura del metodo ToString
        /// </summary>
        /// <returns>retorna todos los datos de un Contacto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append($"- {this.telefono} - ");
            sb.Append($"{this.peso} Kg - ");
            sb.Append($"{this.altura} Mt - ");
            sb.Append($"IMC: {this.imc} - ");
            sb.Append($"{this.composicionCorporal} - ");
            sb.Append($"{this.gradoObesidad} ");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrescritura del metodo Equals
        /// </summary>
        /// <param name="obj">objeto a validar igualdad</param>
        /// <returns>retorna true si los objetos son iguales(usando el criterio de igualacion de los contactos), sino retorna false</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Contacto)
            {
                retorno = (Contacto)obj == this;
            }
            return retorno;
        }

        /// <summary>
        /// Calcula el IMC de un Contacto
        /// </summary>
        /// <returns>retorna IMC calculado</returns>
        public double CalcularIMC()
        {
            double retornoImc;
            retornoImc = this.peso / Math.Pow(this.altura, 2);
            return retornoImc;
        }

        /// <summary>
        /// Calcula la composicion comporar de un Contacto en base a su IMC
        /// </summary>
        /// <param name="imc">Imc de un Contacto</param>
        /// <returns>retorna un EComposisionCorporal (Bajo_peso, Norma, Sobrepeso u Obesidad)</returns>
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

        /// <summary>
        /// Calcula el grado de obesidad de un Contacto en base a la composicion corporal y al IMC
        /// </summary>
        /// <param name="composicion"></param>
        /// <returns>Si el Contacto es obeso retorna el grado de obesidad, sino retorna No_obeso</returns>
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
