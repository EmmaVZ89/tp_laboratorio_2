using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Cliente : Contacto
    {
        private int dni;
        private string email;
        private EPlan plan;

        public int Dni
        {
            get
            {
                return this.dni;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
        }
        public EPlan Plan
        {
            get
            {
                return this.plan;
            }
        }

        public Cliente(string nombre, int edad, string sexo, int telefono, double peso, double altura)
            : base(nombre, edad, sexo, telefono, peso, altura)
        {
        }

        public Cliente(string nombre, int edad, string sexo, int telefono, double peso, double altura,
            int dni, string email, EPlan plan)
            : this (nombre, edad, sexo, telefono, peso, altura)
        {
            this.dni = dni;
            this.email = email;
            this.plan = plan;
        }

        public static bool operator == (Cliente c1, Cliente c2)
        {
            bool retorno = false;

            if(c1.dni == c2.dni)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"E-mail: {this.email}");
            sb.AppendLine($"Plan: {this.plan}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj.GetType() == typeof(Cliente))
            {
                retorno = (Cliente)obj == this;
            }
            return retorno;
        }


    }
}
