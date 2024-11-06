using System;

namespace TP
{
    public class Colectivo
    {
        protected float tarifa = 1200;
        private float saldoNegativoPermitido = -480;
        private string linea;
        private Boleto boleto;

        public Colectivo(string linea)
        {
            this.linea = linea;
        }

        public Boleto PagarCon(Tarjeta tarjeta)
        {
            float tarifaAplicada;
            tarifaAplicada = tarjeta.CalcularTarifa(tarifa);

            if (tarjeta.ObtenerSaldo() - tarifaAplicada >= saldoNegativoPermitido)
            {
                tarjeta.DescontarSaldo(tarifaAplicada);
                boleto = new Boleto(tarifaAplicada, tarjeta.GetType().Name, this.linea, tarjeta.ObtenerSaldo(), tarjeta.ObtenerId());
                return boleto;
            }

            return null;
        }
    }
}