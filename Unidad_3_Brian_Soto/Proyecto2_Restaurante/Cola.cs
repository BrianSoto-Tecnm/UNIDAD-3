namespace Proyecto2_Restaurante
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;

        public bool Vacia()
        {
            return frente == null;
        }

        public void Encolar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            if (frente == null)
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Cliente Desencolar()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            return cliente;
        }

        public Cliente Buscar(string nombre)
        {
            Nodo actual = frente;

            while (actual != null)
            {
                if (actual.Datos.Nombre == nombre)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(string nombre)
        {
            if (frente == null)
                return false;

            if (frente.Datos.Nombre == nombre)
            {
                frente = frente.Siguiente;

                if (frente == null)
                    final = null;

                return true;
            }

            Nodo anterior = frente;

            while (anterior.Siguiente != null)
            {
                if (anterior.Siguiente.Datos.Nombre == nombre)
                {
                    anterior.Siguiente = anterior.Siguiente.Siguiente;

                    if (anterior.Siguiente == null)
                        final = anterior;

                    return true;
                }

                anterior = anterior.Siguiente;
            }

            return false;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay clientes en espera.");
                return;
            }

            int posicion = 1;
            Nodo actual = frente;

            while (actual != null)
            {
                Console.WriteLine($"{posicion}. {actual.Datos}");

                posicion++;
                actual = actual.Siguiente;
            }
        }
    }
}
