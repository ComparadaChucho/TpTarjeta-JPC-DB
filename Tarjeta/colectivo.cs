using System;

namespace TP
{
    public class Colectivo
    {
        private float tarifa = 1200;
        private float tarifaInterurbano = 2500;
        private float saldoNegativoPermitido = -480;
        public bool interurbano;
        private string linea;
        private Boleto boleto;

        public Colectivo(string linea, bool interurbano)
        {
            this.linea = linea;
            this.interurbano = interurbano;
        }

        public Boleto PagarCon(Tarjeta tarjeta)
        {
            float tarifaAplicada;

            if (interurbano == true)
            {
                tarifa = 2500;
                tarifaAplicada = tarjeta.CalcularTarifa(tarifa);
            }
            else
            {
                tarifaAplicada = tarjeta.CalcularTarifa(tarifa);
            }

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