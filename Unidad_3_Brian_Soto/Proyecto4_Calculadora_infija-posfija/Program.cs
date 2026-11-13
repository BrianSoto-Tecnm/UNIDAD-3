// ==================================================================
// PROYECTO 4. CALCULADORA DE EXPRESIONES MATEMATICAS
// Convierte expresiones: Infija -> Postfija -> Evaluacion.
// Ejemplo: (3 + 2) * 2  ->  3 2 + 2 *  ->  Resultado = 10
// La clase Calculadora convierte expresiones infijas a postfijas y
// posteriormente las evalua utilizando pilas.
// Funciones: validar expresion, convertir infija a postfija,
// evaluar expresion postfija, manejar parentesis, manejar los
// operadores + - * / % ^ y detectar errores matematicos.
// ==================================================================
using System;

namespace Proyecto4_Calculadora
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== CALCULADORA ===");

            Console.Write("Expresion: ");
            string expresion = Console.ReadLine()!;

            Calculadora calculadora = new Calculadora();

            if (!calculadora.ValidarExpresion(expresion))
            {
                Console.WriteLine("Expresion invalida.");
                Console.ReadKey();
                return;
            }

            string postfija = calculadora.ConvertirInfijaAPostfija(expresion);

            Console.WriteLine($"Postfija: {postfija}");
            Console.WriteLine(calculadora.EvaluarPostfija(postfija));

            Console.ReadKey();
        }
    }
}
