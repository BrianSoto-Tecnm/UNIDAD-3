// ==================================================================
// PROYECTO 1. SISTEMA DE GESTION DE PACIENTES DE UNA CLINICA
// Sistema para administrar la atencion en una clinica. El sistema
// registra pacientes de: Emergencia, Urgente, Consulta general y
// Cita programada. Los pacientes deben ser atendidos respetando
// las reglas de prioridad (las emergencias se atienden primero).
// Funciones con menu: registrar pacientes, eliminar paciente,
// buscar paciente por expediente, mostrar pacientes en espera,
// atender paciente en espera, atender siguiente paciente,
// asignar paciente, mostrar historial de pacientes atendidos y
// consultar cantidad de pacientes en espera.
// Estructuras: Lista enlazada (pacientes registrados), Cola
// (pacientes en espera) y Cola de prioridad (emergencias).
// Justificacion de la cola: se usa una cola (FIFO) porque los
// pacientes se atienden en el mismo orden en que llegan; el
// primero que entra a la fila es el primero en ser atendido.
// ==================================================================
namespace Proyecto1_Clinica
{
    public class Paciente
    {
        public int Expediente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public Paciente(int expediente, string nombre, int edad, string tipo)
        {
            Expediente = expediente;
            Nombre = nombre;
            Edad = edad;
            Tipo = tipo;
            Estado = "En espera";
        }

        public override string ToString()
        {
            return $"Expediente: {Expediente} | {Nombre} | Edad: {Edad} | {Tipo} | {Estado}";
        }
    }
}
