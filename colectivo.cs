using System;

namespace TP
{
    public class Colectivo
    {
        private float tarifa = 940;

        public Boleto PagarCon(Tarjeta tarjeta)
        {
            if (tarjeta.DescontarSaldo(tarifa))
            {
                Console.WriteLine($"Pago realizado correctamente. Tarifa: ${tarifa}");
                return new Boleto(tarifa);
            }
            return null;
        }
    }
}
