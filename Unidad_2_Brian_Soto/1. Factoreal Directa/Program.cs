
class Program
{
    static long Factorial(int n)
    {
        if (n == 0)
            return 1;
        else
            return n * Factorial(n - 1);
    }
    static void Main()
    {
        Console.WriteLine("Ingrese un numero: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0 || n > 20)
        {
            Console.WriteLine("Ingrese un numero entre el 0 y 20: ");
            return;
        }
        Console.WriteLine("Factorial: " + Factorial(n));

    }

}
