using sistem;

namespace Proyecto4_Calculadora
{
    internal class Program
    {
        static int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;
            if (operador == '*' || operador == '/')
                return 2;
            if (operador == '^')
                return 3;
            
                return 0;
        }

        
    }
}