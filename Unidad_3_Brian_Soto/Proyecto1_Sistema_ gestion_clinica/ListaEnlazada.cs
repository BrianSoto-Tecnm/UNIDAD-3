namespace Proyecto1_Clinica
{
    public class ListaEnlazada
    {
        private Nodo inicio;

        public void Agregar(Paciente paciente)
        {
            Nodo nuevo = new Nodo(paciente);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                Nodo actual = inicio;

                while (actual.Siguiente != null)
                    actual = actual.Siguiente;

                actual.Siguiente = nuevo;
            }
        }

        public Paciente Buscar(int expediente)
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                if (actual.Datos.Expediente == expediente)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(int expediente)
        {
            if (inicio == null)
                return false;

            if (inicio.Datos.Expediente == expediente)
            {
                inicio = inicio.Siguiente;
                return true;
            }

            Nodo anterior = inicio;

            while (anterior.Siguiente != null)
            {
                if (anterior.Siguiente.Datos.Expediente == expediente)
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
            if (inicio == null)
            {
                Console.WriteLine("No hay pacientes.");
                return;
            }

            Nodo actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }
    }
}
