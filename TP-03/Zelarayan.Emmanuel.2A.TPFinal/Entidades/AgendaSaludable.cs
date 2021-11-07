using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AgendaSaludable<T>
        where T : Persona
    {
        private List<T> listadoPersonas;

        public List<T> ListaPersonas
        {
            get
            {
                return this.listadoPersonas;
            }
            set
            {
                this.listadoPersonas = value;
            }
        }

        public AgendaSaludable()
        {
            this.listadoPersonas = new List<T>();
        }

        public static bool operator == (AgendaSaludable<T> agenda, T persona)
        {
            bool retorno = false;
            foreach (T item in agenda.listadoPersonas)
            {
                if(item.Equals(persona))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator != (AgendaSaludable<T> agenda, T persona)
        {
            return !(agenda == persona);
        }

        public static AgendaSaludable<T> operator + (AgendaSaludable<T> agenda, T persona)
        {
            if(agenda != persona)
            {
                agenda.listadoPersonas.Add(persona);
            }
            return agenda;
        }

        public static AgendaSaludable<T> operator - (AgendaSaludable<T> agenda, T persona)
        {
            if(agenda == persona)
            {
                agenda.listadoPersonas.Remove(persona);
            }
            return agenda;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** AGENDA SALUDABLE ***\n");
            sb.AppendLine($"Cantidad de contactos: {this.listadoPersonas.Count}\n");
            foreach (T item in this.listadoPersonas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
