using System;


namespace App_Consola // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Biblioteca.Mascota mascota = new Biblioteca.Mascota();
            mascota.nombre = "guagua";
            mascota.raza = "sbrigida";

            Console.WriteLine(mascota.nombre);
            Console.WriteLine(mascota.raza);
        }
    }
}