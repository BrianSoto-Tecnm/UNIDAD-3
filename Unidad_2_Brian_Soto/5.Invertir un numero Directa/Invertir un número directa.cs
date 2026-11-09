using system;

class Program
{
    static long Invertir(long n, long resultado = 0)
    {
        if (n == 0)
            return resultado;

        return Invertir(n / 10, resultado * 10 + n % 10);
    }

    static void Main()
    {
        Console.Write("Ingresa el numero positivo: ");
        long n = long.Parse(Console.ReadLine());

        if (n<0)
        {
            Console.WriteLine("El numero debe ser positivo.");
            return;
        }

        Console.WriteLine("Numero invertido:" + Invertir(n));
    }
}
