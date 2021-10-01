using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller // agregue modificador sealed
    {
        public enum ETipo
        {
            // modifique nombres en la lista por el nombre correcto de las clases
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

        private List<Vehiculo> vehiculos;// agregue modificador private
        private int espacioDisponible;// agregue modificador private

        #region "Constructores"

        /// <summary>
        /// Instancia un elemento tipo taller por defecto, inicializa lista.
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Instancia un elemento tipo Taller, inicializando la lista e indicando el espacioDisponible
        /// </summary>
        /// <param name="espacioDisponible">espacio total disponible en el taller, tipo int</param>
        public Taller(int espacioDisponible) : this() // se utiliza la sobrecarga para que se inicialice la lista de vehiculos
        {
            this.espacioDisponible = espacioDisponible;
        }

        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>retorna una string con todos los datos del estacionamiento</returns>
        public override string ToString() // agregue el modificador override
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible + taller.vehiculos.Count); // muestro el espacio total disponible sumando el espacio ocupado y el espacio disponible actual
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    // cambie los tipos por los correspondientes (SUV, Ciclomotor, Sedan)
                    // En cada case se pregunta si el vehiculo es de ese tipo, porque de lo contrario se imprime toda las lista de vehiculos.
                    case ETipo.SUV:
                        if(v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if(v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString(); // convierto el sb en una string
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>retorna el elemento tipo Taller pasado por parametro, se haya podido agregar el vehiculo o no.</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            bool flagAgregarVehiculo = true;

            foreach (Vehiculo v in taller.vehiculos) // correcion de foreach, puse taller.vehiculos
            {
                if (v == vehiculo)
                {
                    flagAgregarVehiculo = false; // si el vehiculo esta en la lista la variable cambia de valor
                    break;
                }
            }

            if(flagAgregarVehiculo && taller.espacioDisponible > 0) // si la variable no camcio de valor (true) y hay espacio disponible se agregara el vehiculo al taller
            {
                taller.vehiculos.Add(vehiculo);
                taller.espacioDisponible--;// al eliminar un vehiculo tengo que restar espacio disponible
            }
            
            return taller; // siempre de retorna el taller, sin importar si se agrego un vehiculo o no.
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>retorna el elemento tipo Taller pasado por parametro, se haya podido eliminar el vehiculo o no.</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos) // correcion de foreach, puse taller.vehiculos
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    taller.espacioDisponible++;// al eliminar un vehiculo tengo que sumar espacio disponible
                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
