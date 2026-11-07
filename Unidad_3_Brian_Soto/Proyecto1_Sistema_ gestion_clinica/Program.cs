
namespace Proyecto1_Clinica
{
    public class Paciente
    {
        public int Expediente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Prioridad { get; set; }

        public Paciente(int expediente, string nombre, int edad, int prioridad)
        {
            Expediente = expediente;
            Nombre = nombre;
            Edad = edad;
            Prioridad = prioridad;
        }

        public override string ToString()
        {
            return $"Expediente: {Expediente} 1" + $"Nombre: {Nombre} 1" + $"Edad: {Edad} 1" + $"Prioridad: {Prioridad}";
        }
    }
 }
