using System;

namespace TP
{
    public class Colectivo
    {
        private float tarifa = 940;
        private float saldoNegativoPermitido = -480;
        private string linea;
        private Boleto boleto;

        public Colectivo(string linea)
        {
            this.linea = linea;
        }

        public Boleto PagarCon(Tarjeta tarjeta)
        {
            float tarifaAplicada = tarjeta.CalcularTarifa(tarifa);

            if (tarjeta.Saldo - tarifaAplicada >= saldoNegativoPermitido)
            {
                tarjeta.DescontarSaldo(tarifaAplicada);
                boleto = new Boleto(tarifaAplicada, tarjeta.GetType().Name, this.linea, tarjeta.Saldo, tarjeta.ObtenerId());
                return boleto;
            }

            return null;
        }
    }
}