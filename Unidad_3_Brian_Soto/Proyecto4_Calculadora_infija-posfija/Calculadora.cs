namespace Proyecto4_Calculadora
{
    public class Calculadora
    {
        public bool ValidarExpresion(string expresion)
        {
            if (string.IsNullOrWhiteSpace(expresion))
                return false;

            int balance = 0;

            foreach (char caracter in expresion)
            {
                if (caracter == '(')
                {
                    balance++;
                }
                else if (caracter == ')')
                {
                    balance--;

                    if (balance < 0)
                        return false;
                }
                else if (!char.IsDigit(caracter) && !"+-*/%^ ".Contains(caracter))
                    return false;
            }

            return balance == 0;
        }

        public string ConvertirInfijaAPostfija(string expresion)
        {
            Pila pila = new Pila();
            string salida = "";

            foreach (char caracter in expresion)
            {
                if (char.IsDigit(caracter))
                {
                    salida += caracter;
                }
                else if (caracter == '(')
                {
                    salida += ' ';
                    pila.Apilar(caracter);
                }
                else if (caracter == ')')
                {
                    salida += ' ';

                    while (!pila.Vacia() && pila.Tope() != '(')
                    {
                        salida += pila.Desapilar();
                        salida += ' ';
                    }

                    pila.Desapilar();
                }
                else if ("+-*/%^".Contains(caracter))
                {
                    salida += ' ';

                    while (!pila.Vacia() && Prioridad(pila.Tope()) >= Prioridad(caracter))
                    {
                        salida += pila.Desapilar();
                        salida += ' ';
                    }

                    pila.Apilar(caracter);
                }
                else
                {
                    salida += ' ';
                }
            }

            while (!pila.Vacia())
            {
                salida += ' ';
                salida += pila.Desapilar();
            }

            return string.Join(" ", salida.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        public string EvaluarPostfija(string postfija)
        {
            PilaNumeros pila = new PilaNumeros();

            string[] partes = postfija.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string parte in partes)
            {
                if (int.TryParse(parte, out int numero))
                {
                    pila.Apilar(numero);
                }
                else
                {
                    if (pila.Vacia())
                        return "Error: expresion invalida.";

                    int b = pila.Desapilar();

                    if (pila.Vacia())
                        return "Error: expresion invalida.";

                    int a = pila.Desapilar();

                    if (parte == "+")
                        pila.Apilar(a + b);
                    else if (parte == "-")
                        pila.Apilar(a - b);
                    else if (parte == "*")
                        pila.Apilar(a * b);
                    else if (parte == "/")
                    {
                        if (b == 0)
                            return "Error: division entre cero.";

                        pila.Apilar(a / b);
                    }
                    else if (parte == "%")
                    {
                        if (b == 0)
                            return "Error: division entre cero.";

                        pila.Apilar(a % b);
                    }
                    else if (parte == "^")
                        pila.Apilar((int)Math.Pow(a, b));
                }
            }

            if (pila.Vacia())
                return "Error: expresion invalida.";

            int resultado = pila.Desapilar();

            if (!pila.Vacia())
                return "Error: expresion invalida.";

            return $"Resultado = {resultado}";
        }

        private int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;

            if (operador == '*' || operador == '/' || operador == '%')
                return 2;

            if (operador == '^')
                return 3;

            return 0;
        }
    }
}
