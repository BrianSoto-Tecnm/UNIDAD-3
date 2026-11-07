using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;
        public Cola()
        {
            frente = null;
            final = null;
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

        public void Mostrar ()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay pacientes registrados en este programa, ya que no se han registrado porque no han querido registrarse.");
                return;
            }
            Nodo aux = frente;
            while (aux != null)
            {
                Console.WriteLine(aux.Datos);
                aux = aux.Siguiente
            }
        }

        public void 
        
    }
}

