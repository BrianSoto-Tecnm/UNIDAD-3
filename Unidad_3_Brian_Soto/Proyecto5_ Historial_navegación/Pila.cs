using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto5_Navegador
{
    public class Pila
    {
        private Nodo tope;

        private class Nodo
        {
            public string Pagina;
            public Nodo Siguiente;

            public Nodo(string pagina)
            {
                Pagina = pagina;
                Siguiente = null;
            }
        }

        public void Push(string pagina)
        {
            Nodo nuevo = new Nodo(pagina);

            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public string Pop()
        {
            if (tope == null)
                return null;

            string pagina = tope.Pagina;
            tope = tope.Siguiente;

            return pagina;
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public bool Buscar(string pagina)
        {
            Nodo actual = tope;

            while (actual != null)
            {
                if (actual.Pagina == pagina)
                    return true;

                actual = actual.Siguiente;
            }

            return false;
        }

        public void Vaciar()
        {
            tope = null;
        }

        public void Mostrar()
        {
            if (tope == null)
            {
                Console.WriteLine("(vacia)");
                return;
            }

            Nodo actual = tope;

            while (actual != null)
            {
                Console.WriteLine(actual.Pagina);
                actual = actual.Siguiente;
            }
        }
    }
}
