using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Proyecto1_Clinica
{
    internal class Program
    {
        static Cola pacientes = new Cola();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("----- CLINICA -----");
                Console.WriteLine("1. Ingresar paciente");
                Console.WriteLine("2. Atender paciente");
                Console.WriteLine("3. Muestra paciente");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Opcion:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;

                    case 2:
                        Atender();
                        break;

                    case 3:
                        pacientes.Mostrar();
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }

        static void Registrar()
        {
            Console.Write("Expediente:");
            int expediente = int.Parse(Console.ReadLine();

            Console.Write("Nombre:");
            string nombre = Console.ReadLine();

            Console.Write("Edad:");
            int edad = int.Parse(Console.ReadLine();

            Console.Write("Prioridad:");
            int prioridad = int.Parse(Console.ReadLine();

            Paciente paciente = new Paciente(expediente, nombre, edad, prioridad);

            pacientes.Encolar(paciente);

            Console.WriteLine("Paciente registrado.");
            Console.ReadKey();
        }

        static void Atender()
        {
            Paciente paciente = pacientes.Desencolar();

            if (paciente == null)
                Console.WriteLine("No hay pacientes.");
            else
                Console.ReadLine("Atendiendo:");

            if (paciente != null)
                Console.WriteLine(paciente);
            Console.ReadKey();
        }
    }
}
