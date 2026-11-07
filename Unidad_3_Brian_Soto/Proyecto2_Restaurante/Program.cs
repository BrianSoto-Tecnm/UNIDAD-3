using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    internal class Program
    {
        static Cola espera = new Cola();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("----- MENU RESTAURANTE -----");
                Console.WriteLine("1. Agregar cliente.");
                Console.WriteLine("2. Asignar mesa.");
                Console.WriteLine("3. Mostrar espera.");
                Console.WriteLine("0. Salir .");
                Console.Write("Opcion:");

                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        Agregar();
                            break;
                    case 2:
                        AsignarMesa();
                            break;
                    case 3:
                        espera.Mostrar();
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }

        static void Agregar()
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine()!;

            Console.WriteLine("Numero de personas: ");
            int personas = int.Parse(Console.ReadLine()!);

            espera.Encolar(new Cliente(nombre, personas));

            Console.WriteLine("Cliente agregado.");
            Console.ReadKey();
        }

        static void AsignarMesa()
        {
            Cliente cliente = espera.Desencolar();

            if (cliente == null)
                Console.WriteLine("No hay cliente.");
            else
                Console.WriteLine($"Mesa asignada a {cliente}");

            Console.ReadKey();
        }
    }
}
