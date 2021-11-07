﻿using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creo una Persona
            Persona p1 = new Persona
            (
                "Victor", 24, "Hombre"
            );

            // Muestro datos completos de la Persona
            //Console.WriteLine(p1);

            // Creo un Contacto
            Contacto c1 = new Contacto
            (
                "Benjamin", 24, "Hombre", 13131313, 140, 1.74
            );

            // Muestro datos completos del Contacto
            //Console.WriteLine(c1);

            // Creo un Cliente
            Cliente cli1 = new Cliente
            (
                "Soledad", 33, "Mujer", 12121212, 73, 1.65, 33123123, "sole@gmail.com", EPlan.Bronce
            );

            // Muestro datos completos del Cliente
            //Console.WriteLine(cli1);

            // Se crea una AgendaSaludable
            AgendaSaludable<Persona> agenda = new AgendaSaludable<Persona>();

            // Se agregan objetos a la agenda
            agenda += p1;
            agenda += c1;
            agenda += cli1;
            agenda += cli1;
            agenda += cli1;

            // Se muestra todo el contenido de la Agenda
            Console.WriteLine(agenda);

            // Se borra p1 de la agenda
            agenda -= p1;
            agenda -= cli1;
            agenda -= p1;

            Console.ReadKey();
            Console.Clear();

            // Se muestra denuevo la agenda
            Console.WriteLine(agenda);


            Console.ReadKey();
        }
    }
}
