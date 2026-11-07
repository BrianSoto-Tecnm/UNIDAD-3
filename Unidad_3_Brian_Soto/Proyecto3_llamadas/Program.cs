using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto3_llamadas
{
    internal class Program
    {
        static Pila llamadas = new Pila();
        static PilaProcesos procesos = new PilaProcesos();

        static Llamada ultimaAfectada;
        static string accionAnterior;
        static string estadoAnterior;

        static void Main()
        {
            procesos.Apilar("Main()");
            Console.WriteLine(">>> Inicia el programa. Se APILA en la memoria: Main()");

            MenuPrincipal();

            Console.WriteLine(">>> Fin del programa. La memoria de llamadas quedo vacia.");
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

        static void MenuPrincipal()
        {
            procesos.Apilar("MenuPrincipal()");
            Console.WriteLine(">>> Main() llama a MenuPrincipal()");
            Console.WriteLine();

            int opcion;

            do
            {
                Limpiar();

                Console.WriteLine("----- SIMULADOR DE LLAMADAS TELEFONICAS -----");
                Console.WriteLine("1. Registrar llamada (cliente)");
                Console.WriteLine("2. Atender llamada");
                Console.WriteLine("3. Finalizar llamada");
                Console.WriteLine("4. Mostrar llamadas");
                Console.WriteLine("5. Recuperar (estado anterior)");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("8. Ver pila de procesos (memoria de metodos)");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion:");

                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;

                    case 2:
                        AtenderLlamada();
                        break;

                    case 3:
                        FinalizarLlamada();
                        break;

                    case 4:
                        MostrarLlamadas();
                        break;

                    case 5:
                        RecuperarLlamada();
                        break;

                    case 6:
                        BuscarLlamada();
                        break;

                    case 7:
                        EliminarLlamada();
                        break;

                    case 8:
                        MostrarMemoria();
                        break;
                }
            } while (opcion != 0);

            procesos.Desapilar();
            Console.WriteLine("<<< Termina MenuPrincipal(). El control regresa a Main().");
        }

        static void Entrar(string metodo)
        {
            procesos.Apilar(metodo);
            Console.WriteLine($">>> Entra {metodo} (se APILA en la memoria de llamadas)");
        }

        static void Regresar(string metodo)
        {
            procesos.Desapilar();
            Console.WriteLine($"<<< Termina {metodo}. Regresa al estado anterior: MenuPrincipal()");
        }

        static void RegistrarCliente()
        {
            Entrar("RegistrarCliente()");

            Console.Write("Numero:");
            int numero = int.Parse(Console.ReadLine()!);

            Console.Write("Nombre:");
            string nombre = Console.ReadLine()!;

            if (BuscarCliente(numero))
            {
                Console.WriteLine("Ya existe una llamada con ese numero.");
            }
            else
            {
                llamadas.Apilar(new Llamada(numero, nombre));
                Console.WriteLine($"Registrado de: {nombre}  (# {numero})");
            }

            Pausar();
            Regresar("RegistrarCliente()");
        }

        static bool BuscarCliente(int numero)
        {
            Entrar("BuscarCliente()");

            bool existe = (llamadas.Buscar(numero) != null);

            if (existe)
                Console.WriteLine("BuscarCliente(): el numero ya esta en la pila de llamadas.");
            else
                Console.WriteLine("BuscarCliente(): el numero esta libre, se puede registrar.");

            procesos.Desapilar();
            Console.WriteLine("<<< Termina BuscarCliente(). Regresa a RegistrarCliente()");

            return existe;
        }

        static void AtenderLlamada()
        {
            Entrar("AtenderLlamada()");

            Llamada llamada = llamadas.Cima();

            if (llamada == null)
                Console.WriteLine("No hay llamadas para atender.");
            else
            {
                ultimaAfectada = llamada;
                accionAnterior = "Atender";
                estadoAnterior = llamada.Estado;

                llamada.Estado = "Atendida";
                Console.WriteLine($"Atendiendo a: {llamada}");
            }

            Pausar();
            Regresar("AtenderLlamada()");
        }

        static void FinalizarLlamada()
        {
            Entrar("FinalizarLlamada()");

            Llamada llamada = llamadas.Desapilar();

            if (llamada == null)
                Console.WriteLine("No hay llamadas que finalizar.");
            else
            {
                ultimaAfectada = llamada;
                accionAnterior = "Finalizar";
                estadoAnterior = llamada.Estado;

                llamada.Estado = "Finalizada";
                Console.WriteLine($"Llamada finalizada y retirada de la pila: {llamada}");
            }

            Pausar();
            Regresar("FinalizarLlamada()");
        }

        static void MostrarLlamadas()
        {
            Entrar("MostrarLlamadas()");

            llamadas.Mostrar();
            Console.WriteLine("(Se atiende desde arriba hacia abajo: LIFO)");

            Pausar();
            Regresar("MostrarLlamadas()");
        }

        static void RecuperarLlamada()
        {
            Entrar("RecuperarLlamada()");

            if (ultimaAfectada == null)
            {
                Console.WriteLine("No hay nada que recuperar.");
            }
            else if (accionAnterior == "Finalizar")
            {
                ultimaAfectada.Estado = estadoAnterior;
                llamadas.Apilar(ultimaAfectada);
                Console.WriteLine($"La llamada {ultimaAfectada} regreso a la pila.");
            }
            else if (accionAnterior == "Atender")
            {
                ultimaAfectada.Estado = estadoAnterior;
                Console.WriteLine($"La llamada {ultimaAfectada} regreso a su estado anterior.");
            }

            ultimaAfectada = null;
            accionAnterior = null;
            estadoAnterior = null;

            Pausar();
            Regresar("RecuperarLlamada()");
        }

        static void BuscarLlamada()
        {
            Entrar("BuscarLlamada()");

            Console.Write("Numero a buscar:");
            int numero = int.Parse(Console.ReadLine()!);

            Llamada llamada = llamadas.Buscar(numero);

            if (llamada == null)
                Console.WriteLine("No se encontro la llamada.");
            else
                Console.WriteLine($"Encontrada: {llamada}");

            Pausar();
            Regresar("BuscarLlamada()");
        }

        static void EliminarLlamada()
        {
            Entrar("EliminarLlamada()");

            Console.Write("Numero a eliminar:");
            int numero = int.Parse(Console.ReadLine()!);

            if (llamadas.Eliminar(numero))
                Console.WriteLine("Llamada eliminada de la pila.");
            else
                Console.WriteLine("No se encontro la llamada.");

            Pausar();
            Regresar("EliminarLlamada()");
        }

        static void MostrarMemoria()
        {
            Entrar("MostrarMemoria()");

            procesos.Mostrar();
            Console.WriteLine("(Asi guarda el programa los metodos en memoria: ultimo arriba)");

            Pausar();
            Regresar("MostrarMemoria()");
        }
    }
}
