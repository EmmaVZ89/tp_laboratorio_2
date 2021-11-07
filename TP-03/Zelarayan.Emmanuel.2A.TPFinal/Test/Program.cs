using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creo una primer Persona
            Persona p1 = new Persona
            (
                "Victor", 24, "Hombre"
            );

            // Muestro datos completos de la Persona
            Console.WriteLine(p1);

            // Creo un Contacto
            Contacto c1 = new Contacto
            (
                "Victor", 24, "Hombre", 13131313, 74.5, 1.74
            );

            // Muestro datos completos del Contacto
            Console.Write(c1);




            Console.ReadKey();
        }
    }
}
