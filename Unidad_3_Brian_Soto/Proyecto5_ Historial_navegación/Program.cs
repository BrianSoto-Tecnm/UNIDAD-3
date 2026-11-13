// ==================================================================
// PROYECTO 5. SISTEMA DE HISTORIAL DE NAVEGACION WEB
// Navegador web simulado que almacena las paginas visitadas.
// Funciones: visitar pagina, regresar (atras), avanzar (adelante),
// mostrar historial, eliminar historial, buscar una pagina y
// mostrar la ultima pagina registrada.
// Estructura: dos pilas (pila atras y pila adelante).
// ==================================================================
using System;

namespace Proyecto5_Navegador
{
    internal class Program
    {
        static Pila atras = new Pila();
        static Pila adelante = new Pila();

        static string actual = "Inicio";

        static void Main()
        {
            int opcion;

            do
            {
                Limpiar();

                Console.WriteLine("=== NAVEGADOR ===");
                Console.WriteLine($"Pagina actual: {actual}");
                Console.WriteLine("1. Visitar pagina");
                Console.WriteLine("2. Atras (regresar)");
                Console.WriteLine("3. Adelante (avanzar)");
                Console.WriteLine("4. Mostrar historial");
                Console.WriteLine("5. Eliminar historial");
                Console.WriteLine("6. Buscar pagina");
                Console.WriteLine("7. Mostrar ultima pagina registrada");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: ");

                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        atras.Push(actual);

                        Console.Write("Nueva pagina: ");
                        actual = Console.ReadLine()!;

                        Pausar();
                        break;

                    case 2:
                        string anterior = atras.Pop();

                        if (anterior != null)
                        {
                            adelante.Push(actual);
                            actual = anterior;
                            Console.WriteLine($"Regresando a: {actual}");
                        }
                        else
                            Console.WriteLine("No hay paginas anteriores.");

                        Pausar();
                        break;

                    case 3:
                        string siguiente = adelante.Pop();

                        if (siguiente != null)
                        {
                            atras.Push(actual);
                            actual = siguiente;
                            Console.WriteLine($"Avanzando a: {actual}");
                        }
                        else
                            Console.WriteLine("No hay paginas siguientes.");

                        Pausar();
                        break;

                    case 4:
                        MostrarHistorial();
                        Pausar();
                        break;

                    case 5:
                        atras.Vaciar();
                        adelante.Vaciar();
                        Console.WriteLine("Historial eliminado.");
                        Pausar();
                        break;

                    case 6:
                        BuscarPagina();
                        Pausar();
                        break;

                    case 7:
                        Console.WriteLine($"Ultima pagina registrada: {actual}");
                        Pausar();
                        break;
                }
            } while (opcion != 0);
        }

        static void MostrarHistorial()
        {
            Console.WriteLine("--- PILA ATRAS (la mas reciente arriba) ---");
            atras.Mostrar();
            Console.WriteLine("--- PILA ADELANTE ---");
            adelante.Mostrar();
        }

        static void BuscarPagina()
        {
            Console.Write("Pagina a buscar: ");
            string pagina = Console.ReadLine()!;

            if (atras.Buscar(pagina))
                Console.WriteLine("Encontrada en la pila atras.");
            else if (adelante.Buscar(pagina))
                Console.WriteLine("Encontrada en la pila adelante.");
            else
                Console.WriteLine("No se encontro la pagina.");
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
