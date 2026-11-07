namespace Proyecto3_llamadas
{
    public class Nodo
    {
        public Llamada Datos;
        public Nodo Siguiente;

        public Nodo(Llamada llamada)
        {
            Datos = llamada;
            Siguiente = null;
        }
    }
}
