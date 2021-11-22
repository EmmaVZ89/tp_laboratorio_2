using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase AgendaSaludable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AgendaSaludable<T>
        where T : Persona
    {
        private List<T> listadoPersonas;

        // Propiedad de lectura y escritura del campo listaPersonas
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

        /// <summary>
        /// Constructor por defecto de una AgendaSaludable
        /// </summary>
        public AgendaSaludable()
        {
            this.listadoPersonas = new List<T>();
        }

        /// <summary>
        /// Sobrescritura del operador ==, se comparan una AgendaSaludable y una Persona o derivada.
        /// </summary>
        /// <param name="agenda"> agenda a comparar</param>
        /// <param name="persona">persona a comparar</param>
        /// <returns>retorna true si la persona esta incluida en la agenda, sino retorna false</returns>
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

        /// <summary>
        /// Sobrescritura del operador !=, se comparan una AgendaSaludable y una Persona o derivada.
        /// </summary>
        /// <param name="agenda">agenda a comparar</param>
        /// <param name="persona">persona a comparar</param>
        /// <returns>retorna true si la persona NO esta incluida en la agenda, sino retorna false</returns>
        public static bool operator != (AgendaSaludable<T> agenda, T persona)
        {
            return !(agenda == persona);
        }

        /// <summary>
        /// Agrega, de ser posible, una persona a una agenda
        /// </summary>
        /// <param name="agenda">agenda en la cual se va a agregar la persona</param>
        /// <param name="persona">persona a agregar</param>
        /// <returns>retorna la agenda, con la persona agregada o no.</returns>
        public static AgendaSaludable<T> operator + (AgendaSaludable<T> agenda, T persona)
        {
            if(agenda != persona)
            {
                agenda.listadoPersonas.Add(persona);
            }
            return agenda;
        }

        /// <summary>
        /// Elimina, de ser posible, una persona de una agenda
        /// </summary>
        /// <param name="agenda">agenda de la cual se eliminara la persona</param>
        /// <param name="persona">persona a eliminar</param>
        /// <returns>retorna la agenda, con la persona eliminada o no.</returns>
        public static AgendaSaludable<T> operator - (AgendaSaludable<T> agenda, T persona)
        {
            if(agenda == persona)
            {
                agenda.listadoPersonas.Remove(persona);
            }
            return agenda;
        }

        /// <summary>
        /// Sobrescritura del metodo ToString para mostrar todos los datos de las personas dentro de la agenda.
        /// </summary>
        /// <returns>retorna todos los datos de la agenda</returns>
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
