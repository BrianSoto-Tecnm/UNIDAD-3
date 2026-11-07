namespace Proyecto3_llamadas
{
    public class Llamada
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public Llamada(int numero, string nombre)
        {
            Numero = numero;
            Nombre = nombre;
            Estado = "En espera";
        }

        public override string ToString()
        {
            return $"#{Numero} - {Nombre} - {Estado}";
        }
    }
}
