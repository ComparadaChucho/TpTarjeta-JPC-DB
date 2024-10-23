using System; 

namespace TP
{
    public class Boleto
    {
        public float Tarifa;

        public Boleto(float tarifa)
        {
            this.Tarifa = tarifa;
            Console.WriteLine($"Boleto hecho - Tarifa: ${Tarifa}");
        }

        public override string ToString()
        {
            return $"Boleto hecho - Tarifa: ${Tarifa}";
        }
    }
}
