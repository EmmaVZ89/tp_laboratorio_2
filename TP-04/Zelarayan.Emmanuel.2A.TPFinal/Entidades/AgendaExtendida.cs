using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AgendaExtendida
    {
        /// <summary>
        /// Analiza una Agenda para buscar a las mujeres con bajo peso
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna los datos de las mujeres con bajo peso</returns>
        public static string CalcularMujeresBajoPeso(this AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidadBajoPeso = 0;
            int totalMujeres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Mujer")
                {
                    totalMujeres++;
                    if (contacto.ComposicionCorporal == EComposicionCorporal.Bajo_peso)
                    {
                        cantidadBajoPeso++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if (totalMujeres > 0)
            {
                porcentaje = Math.Round((double)cantidadBajoPeso / totalMujeres * 100, 2);
            }

            sb.AppendLine("*** MUJERES CON BAJO PESO ***\n");
            sb.AppendLine($"Cantidad: {cantidadBajoPeso}  (sobre un total de {totalMujeres} mujeres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para calcular el promedio de IMC, discriminando entre hombre y mujeres,
        /// luego define quien tiene el mayor promedio
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna los promedios calculados</returns>
        public static string CalcularPromedioImc(this AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            double totalImcHombres = 0;
            double totalImcMujeres = 0;
            double promedioImcHombres = 0;
            double promedioImcMujeres = 0;
            int cantidadHombres = 0;
            int cantidadMujeres = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Mujer")
                {
                    cantidadMujeres++;
                    totalImcMujeres += contacto.Imc;
                }
                else
                {
                    cantidadHombres++;
                    totalImcHombres += contacto.Imc;
                }
            }

            if (cantidadHombres > 0)
            {
                promedioImcHombres = Math.Round(totalImcHombres / cantidadHombres, 2);
            }

            if (cantidadMujeres > 0)
            {
                promedioImcMujeres = Math.Round(totalImcMujeres / cantidadMujeres, 2);
            }

            sb.AppendLine("*** PROMEDIO DE IMC ***\n");
            sb.AppendLine($"Cantidad de personas: {agendaContacto.ListaPersonas.Count}");
            sb.AppendLine($"Promedio de IMC en hombres: {promedioImcHombres}, sobre una cantidad de {cantidadHombres} hombres.");
            sb.AppendLine($"Promedio de IMC en Mujeres: {promedioImcMujeres}, sobre una cantidad de {cantidadMujeres} mujeres.\n");

            if (promedioImcHombres > promedioImcMujeres)
            {
                sb.AppendLine($"     *****   Los hombres poseen mayor promedio de IMC ({promedioImcHombres})   *****");
            }
            else if (promedioImcMujeres > promedioImcHombres)
            {
                sb.AppendLine($"     *****   Las mujeres poseen mayor promedio de IMC ({promedioImcMujeres})   *****");
            }
            else
            {
                sb.AppendLine($"     *****   Hombres y mujeres poseen el mismo promedio de IMC ({promedioImcHombres})   *****");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellas mujeres mayores de 30 años y que posean un
        /// grado de obesidad nivel 3.
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna todos los datos de las mujeres que cumplen con la condicion</returns>
        public static string CalcularMujeresObesidadGrado3(this AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalMujeres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Mujer")
                {
                    totalMujeres++;
                    if (contacto.Edad > 30 && contacto.GradoObesidad == EGradoObesidad.Grado_3)
                    {
                        cantidad++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if (totalMujeres > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalMujeres * 100, 2);
            }

            sb.AppendLine("*** MUJERES CON MAS DE 30 AÑOS Y OBESIDAD GRADO 3 ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalMujeres} mujeres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellos hombre menores de 30 años y que posean un 
        /// grado de obesidad nivel 1.
        /// </summary>
        /// <param name="agendaContacto"> agenda a analizar</param>
        /// <returns>retorna todos los datos de los hombres que cumplen con la condicion</returns>
        public static string CalcularHombresObesidadGrado1(this AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalhombres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Hombre")
                {
                    totalhombres++;
                    if (contacto.Edad < 30 && contacto.GradoObesidad == EGradoObesidad.Grado_1)
                    {
                        cantidad++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if (totalhombres > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalhombres * 100, 2);
            }

            sb.AppendLine("*** HOMBRES CON MENOS DE 30 AÑOS Y OBESIDAD GRADO 1 ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalhombres} hombres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellas personas que presentan un peso normal
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna todos los datos de las personas que cumplen con la condicion</returns>
        public static string CalcularPersonasConPesoNormal(this AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalPersonas = agendaContacto.ListaPersonas.Count;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.ComposicionCorporal == EComposicionCorporal.Normal)
                {
                    cantidad++;
                    auxStr += contacto.ToString() + "\n";
                }
            }

            if (totalPersonas > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalPersonas * 100, 2);
            }

            sb.AppendLine("*** PERSONAS CON PESO NORMAL ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalPersonas} personas)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

    }
}
