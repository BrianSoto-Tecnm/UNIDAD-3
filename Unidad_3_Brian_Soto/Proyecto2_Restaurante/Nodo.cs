using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    public class Nodo
    {
        public Cliente Datos;
        public Nodo Siguiente;

        public Nodo(Cliente cliente)
        {
            Datos = cliente;
            Siguiente = null;
        }
    }
}
