namespace Proyecto1_Clinica
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;

        public bool Vacia()
        {
            return frente == null;
        }

        public void Encolar(Paciente paciente)
        {
            Nodo nuevo = new Nodo(paciente);

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

        public Paciente Desencolar()
        {
            if (frente == null)
                return null;

            Paciente paciente = frente.Datos;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            return paciente;
        }

        public int Contar()
        {
            int cantidad = 0;
            Nodo actual = frente;

            while (actual != null)
            {
                cantidad++;
                actual = actual.Siguiente;
            }

            return cantidad;
        }

        public bool Eliminar(int expediente)
        {
            if (frente == null)
                return false;

            if (frente.Datos.Expediente == expediente)
            {
                frente = frente.Siguiente;

                if (frente == null)
                    final = null;

                return true;
            }

            Nodo anterior = frente;

            while (anterior.Siguiente != null)
            {
                if (anterior.Siguiente.Datos.Expediente == expediente)
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
                Console.WriteLine("No hay pacientes.");
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
