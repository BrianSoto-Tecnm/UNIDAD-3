namespace Proyecto3_llamadas
{
    public class PilaProcesos
    {
        private NodoProceso tope;

        public PilaProcesos()
        {
            tope = null;
        }

        public void Apilar(string metodo)
        {
            NodoProceso nuevo = new NodoProceso(metodo);

            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public string Desapilar()
        {
            if (tope == null)
                return null;

            string metodo = tope.Datos;
            tope = tope.Siguiente;

            return metodo;
        }

        public void Mostrar()
        {
            if (tope == null)
            {
                Console.WriteLine("La memoria de procesos esta vacia.");
                return;
            }

            Console.WriteLine("--- MEMORIA DE LLAMADAS A METODOS (el ultimo arriba) ---");

            int nivel = 0;
            NodoProceso actual = tope;

            while (actual != null)
            {
                Console.WriteLine($"[{nivel}] {actual.Datos}");

                nivel++;
                actual = actual.Siguiente;
            }
        }

        private class NodoProceso
        {
            public string Datos;
            public NodoProceso Siguiente;

            public NodoProceso(string metodo)
            {
                Datos = metodo;
                Siguiente = null;
            }
        }
    }
}
