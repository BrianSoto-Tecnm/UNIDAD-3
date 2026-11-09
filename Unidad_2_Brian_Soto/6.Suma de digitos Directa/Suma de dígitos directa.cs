class Program
{
    static int SumarDigitos(int n)
    {
        if (n==0)
            return 0;

        return n % 10 + SumarDigitos(n / 10);
    }

    static void Main()
    {
        Console.Write("Ingresa un numero: ");
        int n = int.Parse(Console.ReadLine());

        if (n <  0)
        {
            Console.WriteLine("Ingresa un numero positivo: ");
            return;
        }

        Console.WriteLine("Suma de digitos: " + SumarDigitos(n));
    }
}
