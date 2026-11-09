class Program
{
    static bool EsPar(int n)
    {
        if (n == 0)
            return true;

        return EsImpar(n - 1);
    }

    static bool EsImpar(int n)
    {
        if (n==0)
            return false;

        return EsPar(n - 1);
    }

    static void Main()
    {
        Console.Write("Ingrese el mumero: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0 || n > 10000)
        {
            Console.WriteLine("Ingresa un numero entre 0 y 10000: ");
            return;
        }

        if (EsPar(n))
            Console.WriteLine("El numero es par");

        else
            Console.WriteLine("El numero es impar");
    }
}
