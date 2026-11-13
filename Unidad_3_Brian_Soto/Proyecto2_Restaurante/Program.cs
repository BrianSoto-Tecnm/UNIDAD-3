// ==================================================================
// PROYECTO 2. SISTEMA DE ASIGNACION DE MESAS DE UN RESTAURANTE
// Simula una lista de espera para la asignacion de mesas en un
// restaurante.
// Funciones: registrar cliente, registrar numero de personas,
// agregar clientes a lista de espera, asignar mesa, cancelar
// reservacion, buscar cliente, eliminar cliente, mostrar lista de
// espera, mostrar mesas disponibles y mostrar mesas ocupadas.
// Estructura: Cola (lista de espera).
// ==================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    internal class Program
    {
        static Cola espera = new Cola();
        static Cliente[] mesas = new Cliente[5];

        static void Main()
        {
            int opcion;

            do
            {
                Limpiar();

                Console.WriteLine("----- MENU RESTAURANTE -----");
                Console.WriteLine("1. Registrar cliente (agregar a lista de espera)");
                Console.WriteLine("2. Asignar mesa");
                Console.WriteLine("3. Cancelar reservacion");
                Console.WriteLine("4. Buscar cliente");
                Console.WriteLine("5. Eliminar cliente");
                Console.WriteLine("6. Mostrar lista de espera");
                Console.WriteLine("7. Mostrar mesas disponibles");
                Console.WriteLine("8. Mostrar mesas ocupadas");
                Console.WriteLine("0. Salir");
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
                        CancelarReservacion();
                        break;

                    case 4:
                        BuscarCliente();
                        break;

                    case 5:
                        EliminarCliente();
                        break;

                    case 6:
                        MostrarEspera();
                        break;

                    case 7:
                        MostrarDisponibles();
                        break;

                    case 8:
                        MostrarOcupadas();
                        break;
                }
            } while (opcion != 0);
        }

        static void Agregar()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;

            Console.Write("Numero de personas: ");
            int personas = int.Parse(Console.ReadLine()!);

            espera.Encolar(new Cliente(nombre, personas));

            Console.WriteLine("Cliente agregado a la lista de espera.");
            Pausar();
        }

        static void AsignarMesa()
        {
            int mesaLibre = -1;

            for (int i = 0; i < mesas.Length; i++)
            {
                if (mesas[i] == null)
                {
                    mesaLibre = i;
                    break;
                }
            }

            if (mesaLibre == -1)
                Console.WriteLine("No hay mesas disponibles.");
            else if (espera.Vacia())
                Console.WriteLine("No hay clientes en espera.");
            else
            {
                Cliente cliente = espera.Desencolar();
                mesas[mesaLibre] = cliente;
                Console.WriteLine($"Mesa {mesaLibre + 1} asignada a {cliente}");
            }

            Pausar();
        }

        static void CancelarReservacion()
        {
            Console.Write("Nombre de la reservacion a cancelar: ");
            string nombre = Console.ReadLine()!;

            if (espera.Eliminar(nombre))
                Console.WriteLine("Reservacion cancelada.");
            else
                Console.WriteLine("No se encontro el cliente en la lista de espera.");

            Pausar();
        }

        static void BuscarCliente()
        {
            Console.Write("Nombre a buscar: ");
            string nombre = Console.ReadLine()!;

            Cliente cliente = espera.Buscar(nombre);

            if (cliente != null)
            {
                Console.WriteLine($"En lista de espera: {cliente}");
            }
            else
            {
                bool sentado = false;

                for (int i = 0; i < mesas.Length; i++)
                {
                    if (mesas[i] != null && mesas[i].Nombre == nombre)
                    {
                        Console.WriteLine($"En la mesa {i + 1}: {mesas[i]}");
                        sentado = true;
                        break;
                    }
                }

                if (!sentado)
                    Console.WriteLine("No se encontro el cliente.");
            }

            Pausar();
        }

        static void EliminarCliente()
        {
            Console.Write("Nombre a eliminar: ");
            string nombre = Console.ReadLine()!;

            if (espera.Eliminar(nombre))
            {
                Console.WriteLine("Cliente eliminado de la lista de espera.");
            }
            else
            {
                bool liberada = false;

                for (int i = 0; i < mesas.Length; i++)
                {
                    if (mesas[i] != null && mesas[i].Nombre == nombre)
                    {
                        mesas[i] = null;
                        Console.WriteLine($"Cliente eliminado. Mesa {i + 1} liberada.");
                        liberada = true;
                        break;
                    }
                }

                if (!liberada)
                    Console.WriteLine("No se encontro el cliente.");
            }

            Pausar();
        }

        static void MostrarEspera()
        {
            espera.Mostrar();
            Pausar();
        }

        static void MostrarDisponibles()
        {
            Console.WriteLine("--- MESAS DISPONIBLES ---");

            int libres = 0;

            for (int i = 0; i < mesas.Length; i++)
            {
                if (mesas[i] == null)
                {
                    Console.WriteLine($"Mesa {i + 1}: Libre");
                    libres++;
                }
            }

            if (libres == 0)
                Console.WriteLine("No hay mesas disponibles.");

            Pausar();
        }

        static void MostrarOcupadas()
        {
            Console.WriteLine("--- MESAS OCUPADAS ---");

            int ocupadas = 0;

            for (int i = 0; i < mesas.Length; i++)
            {
                if (mesas[i] != null)
                {
                    Console.WriteLine($"Mesa {i + 1}: {mesas[i]}");
                    ocupadas++;
                }
            }

            if (ocupadas == 0)
                Console.WriteLine("No hay mesas ocupadas.");

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
