using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    internal class Program
    {
        static ListaEnlazada registrados = new ListaEnlazada();
        static ListaEnlazada historial = new ListaEnlazada();
        static Cola espera = new Cola();
        static ColaPrioridad emergencias = new ColaPrioridad();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Limpiar();

                Console.WriteLine("----- CLINICA -----");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Eliminar paciente");
                Console.WriteLine("3. Buscar paciente por expediente");
                Console.WriteLine("4. Mostrar pacientes en espera");
                Console.WriteLine("5. Atender paciente en espera");
                Console.WriteLine("6. Atender siguiente paciente");
                Console.WriteLine("7. Asignar paciente");
                Console.WriteLine("8. Mostrar historial de pacientes atendidos");
                Console.WriteLine("9. Consultar cantidad de pacientes en espera");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion:");

                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;

                    case 2:
                        Eliminar();
                        break;

                    case 3:
                        Buscar();
                        break;

                    case 4:
                        MostrarEnEspera();
                        break;

                    case 5:
                        AtenderEnEspera();
                        break;

                    case 6:
                        AtenderSiguiente();
                        break;

                    case 7:
                        Asignar();
                        break;

                    case 8:
                        MostrarHistorial();
                        break;

                    case 9:
                        ConsultarCantidad();
                        break;
                }
            } while (opcion != 0);
        }

        static void Registrar()
        {
            Console.Write("Expediente:");
            int expediente = int.Parse(Console.ReadLine()!);

            Console.Write("Nombre:");
            string nombre = Console.ReadLine()!;

            Console.Write("Edad:");
            int edad = int.Parse(Console.ReadLine()!);

            Console.WriteLine("1. Emergencia  2. Urgente  3. Consulta general  4. Cita programada");
            Console.Write("Tipo:");
            int tipo = int.Parse(Console.ReadLine()!);

            string nombreTipo = "Cita programada";

            if (tipo == 1)
                nombreTipo = "Emergencia";
            else if (tipo == 2)
                nombreTipo = "Urgente";
            else if (tipo == 3)
                nombreTipo = "Consulta general";

            Paciente paciente = new Paciente(expediente, nombre, edad, nombreTipo);

            registrados.Agregar(paciente);

            if (tipo == 1)
                emergencias.Encolar(paciente);
            else
                espera.Encolar(paciente);

            Console.WriteLine("Paciente registrado.");
            Pausar();
        }

        static void Eliminar()
        {
            Console.Write("Expediente a eliminar:");
            int expediente = int.Parse(Console.ReadLine()!);

            if (registrados.Eliminar(expediente))
            {
                espera.Eliminar(expediente);
                emergencias.Eliminar(expediente);
                Console.WriteLine("Paciente eliminado.");
            }
            else
                Console.WriteLine("No se encontro el paciente.");

            Pausar();
        }

        static void Buscar()
        {
            Console.Write("Expediente a buscar:");
            int expediente = int.Parse(Console.ReadLine()!);

            Paciente paciente = registrados.Buscar(expediente);

            if (paciente == null)
                Console.WriteLine("No se encontro el paciente.");
            else
                Console.WriteLine(paciente);

            Pausar();
        }

        static void MostrarEnEspera()
        {
            Console.WriteLine("--- EMERGENCIAS (se atienden primero) ---");
            emergencias.Mostrar();
            Console.WriteLine("--- ESPERA NORMAL ---");
            espera.Mostrar();
            Pausar();
        }

        static void AtenderEnEspera()
        {
            Paciente paciente = espera.Desencolar();

            if (paciente == null)
                Console.WriteLine("No hay pacientes en espera.");
            else
            {
                paciente.Estado = "Atendido";
                historial.Agregar(paciente);
                Console.WriteLine($"Paciente atendido: {paciente}");
            }

            Pausar();
        }

        static void AtenderSiguiente()
        {
            Paciente paciente;

            if (!emergencias.Vacia())
                paciente = emergencias.Desencolar();
            else
                paciente = espera.Desencolar();

            if (paciente == null)
                Console.WriteLine("No hay pacientes en espera.");
            else
            {
                paciente.Estado = "Atendido";
                historial.Agregar(paciente);
                Console.WriteLine($"Paciente atendido: {paciente}");
            }

            Pausar();
        }

        static void Asignar()
        {
            Paciente paciente;

            if (!emergencias.Vacia())
                paciente = emergencias.Desencolar();
            else
                paciente = espera.Desencolar();

            if (paciente == null)
                Console.WriteLine("No hay pacientes en espera.");
            else
            {
                paciente.Estado = "En consulta";
                Console.WriteLine($"Paciente asignado a consulta: {paciente}");
            }

            Pausar();
        }

        static void MostrarHistorial()
        {
            Console.WriteLine("--- HISTORIAL DE PACIENTES ATENDIDOS ---");
            historial.Mostrar();
            Pausar();
        }

        static void ConsultarCantidad()
        {
            int enEmergencias = emergencias.Contar();
            int enEspera = espera.Contar();

            Console.WriteLine($"Pacientes en espera: {enEmergencias + enEspera}");
            Console.WriteLine($"  Emergencias: {enEmergencias}");
            Console.WriteLine($"  Espera normal: {enEspera}");
            Pausar();
        }

        static void Limpiar()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
            }
        }

        static void Pausar()
        {
            try
            {
                Console.ReadKey();
            }
            catch
            {
            }
        }
    }
}
