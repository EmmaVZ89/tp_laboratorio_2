using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creo varias Personas
            Persona p1 = new Persona("Victor", 24, "Hombre");
            Persona p2 = new Persona("Jose", 42, "Hombre");
            Persona p3 = new Persona("Maximiliano", 17, "Hombre");
            Persona p4 = new Persona("Miguela", 55, "Mujer");
            Persona p5 = new Persona("Agustina", 32, "Mujer");

            // Muestro datos completos de las Personas
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p5);
            Console.WriteLine();


            // Creo varios Contactos
            Contacto c1 = new Contacto("Benjamin", 24, "Hombre", 13131313, 140, 1.74);
            Contacto c2 = new Contacto("Soledad", 32, "Mujer", 152226554, 74, 1.65);
            Contacto c3 = new Contacto("Juan", 42, "Hombre", 115256545, 95, 1.78);
            Contacto c4 = new Contacto("Celeste", 22, "Mujer", 1526456895, 56, 1.68);
            Contacto c5 = new Contacto("Macarena", 28, "Mujer", 1616161616, 85, 1.80);

            // Muestro datos completos de los Contacto
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            Console.WriteLine(c4);
            Console.WriteLine(c5);

            Console.ReadKey();
            Console.Clear();

            // Se crea una AgendaSaludable
            AgendaSaludable<Persona> agenda = new AgendaSaludable<Persona>();

            // Se agregan objetos a la agenda
            agenda += p1;
            agenda += p2;
            agenda += p3;
            agenda += p4;
            agenda += p4;// no deberia agregarse por duplicado
            agenda += p5;
            agenda += c1;
            agenda += c2;
            agenda += c3;
            agenda += c4;
            agenda += c5;
            agenda += c5;// no deberia agregarse por duplicado

            // Se muestra todo el contenido de la Agenda
            Console.WriteLine(agenda);

            // Se borran elementos de la agenda
            agenda -= p1;
            agenda -= p2;
            agenda -= p2; // no hace nada porque el objeto ya no existe en la agenda
            agenda -= c1;
            agenda -= c2;

            Console.ReadKey();
            Console.Clear();

            // Se muestra denuevo la agenda
            Console.WriteLine(agenda);


            Console.ReadKey();
        }
    }
}
