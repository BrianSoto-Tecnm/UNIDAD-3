namespace Proyecto4_Calculadora
{
    public class PilaNumeros
    {
        private NodoNumero tope;

        private class NodoNumero
        {
            public int Dato;
            public NodoNumero Siguiente;

            public NodoNumero(int dato)
            {
                Dato = dato;
                Siguiente = null;
            }
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public void Apilar(int dato)
        {
            NodoNumero nuevo = new NodoNumero(dato);

            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public int Desapilar()
        {
            if (Vacia())
                return 0;

            int dato = tope.Dato;
            tope = tope.Siguiente;

            return dato;
        }
    }
}
