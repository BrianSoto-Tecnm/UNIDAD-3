//calcular la suma de todos los numeros enteros desde 1 hasta numero integrado
using System;

class Suma
{
    static int SumaRecursiva(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        return n + SumaRecursiva(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("Ingresa un numero entre 0 y 10000:");

        int n;

        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Error: debes ingresar un numero entero.");
            return;
        }

        if (n < 0 || n > 10000)
        {
            Console.WriteLine("Ingresa un numero entre 0 y 10000.");
            return;
        }

        Console.WriteLine("La suma es: " + SumaRecursiva(n));
    }
}