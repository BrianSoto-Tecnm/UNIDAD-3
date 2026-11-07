namespace Proyecto3_llamadas
{
    public class Pila
    {
        private Nodo tope;

        public Pila()
        {
            tope = null;
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public void Apilar(Llamada llamada)
        {
            Nodo nuevo = new Nodo(llamada);

            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public Llamada Desapilar()
        {
            if (tope == null)
                return null;

            Llamada llamada = tope.Datos;
            tope = tope.Siguiente;

            return llamada;
        }

        public Llamada Cima()
        {
            if (tope == null)
                return null;

            return tope.Datos;
        }

        public Llamada Buscar(int numero)
        {
            Nodo actual = tope;

            while (actual != null)
            {
                if (actual.Datos.Numero == numero)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(int numero)
        {
            if (tope == null)
                return false;

            if (tope.Datos.Numero == numero)
            {
                tope = tope.Siguiente;
                return true;
            }

            Nodo anterior = tope;

            while (anterior.Siguiente != null)
            {
                if (anterior.Siguiente.Datos.Numero == numero)
                {
                    anterior.Siguiente = anterior.Siguiente.Siguiente;
                    return true;
                }

                anterior = anterior.Siguiente;
            }

            return false;
        }

        public void Mostrar()
        {
            if (tope == null)
            {
                Console.WriteLine("No hay llamadas registradas.");
                return;
            }

            Console.WriteLine("--- PILA DE LLAMADAS (la cima es la mas reciente) ---");

            int posicion = 1;
            Nodo actual = tope;

            while (actual != null)
            {
                Console.WriteLine($"{posicion}. {actual.Datos}");

                posicion++;
                actual = actual.Siguiente;
            }
        }
    }
}
