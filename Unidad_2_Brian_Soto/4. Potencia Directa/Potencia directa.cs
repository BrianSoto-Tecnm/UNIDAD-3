class Program
{
    static int Potencia(int n, int b)
    {
        if (n == 0)
            return 1;

        return Base(n, b) * Potencia(n - 1, b);
    }

    static int Base(int n, int b)
    {
        return b;
    }

    static void Main()
    {
        Console.Write("Ingresa la base: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Ingresa el exponente: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0 || n > 50)
        {
            Console.WriteLine("Ingresa un numero entre 0 y 50: ");
            return;
        }

        Console.WriteLine("La potencia es: " + Potencia(n, b));
    }
}