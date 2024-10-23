using System;

namespace TP
{
    public class Colectivo
    {
        private float tarifa = 940;
        private float saldoNegativoPermitido = -480;

        public Boleto PagarCon(Tarjeta tarjeta)
        {
            float tarifaAplicada = tarjeta.CalcularTarifa(tarifa);

            if (tarjeta.Saldo - tarifaAplicada >= saldoNegativoPermitido)
            {
                tarjeta.DescontarSaldo(tarifaAplicada);
                Console.WriteLine($"Pago realizado correctamente. Tarifa aplicada: ${tarifaAplicada}");
                return new Boleto(tarifaAplicada);
            }

            Console.WriteLine("Pago fallido. Saldo insuficiente.");
            return null;
        }
    }
}
