using System;

namespace TP
{
    public class Tarjeta
    {
        public float Saldo { get; protected set; }
        public int idTarjeta;
        public float saldoPendiente = 0;
        private float limiteSaldo = 36000;
        private float saldoNegativoPermitido = -480;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        public Tarjeta(float saldoInicial, int id)
        {
            Saldo = saldoInicial;
            this.idTarjeta = id;
        }

        public float ObtenerSaldo()
        {
            return Saldo;
        }

        public int ObtenerId()
        {
            return idTarjeta;
        }

        public bool CargarSaldo(float monto)
        {
            if (Array.Exists(cargasAceptadas, carga => carga == monto))
            {
                if (Saldo + monto > limiteSaldo)
                {
                    float montoCargado = limiteSaldo - Saldo;
                    Saldo = limiteSaldo;
                    saldoPendiente = monto - montoCargado;

                    return true;
                }

                Saldo += monto;
                return true;
            }

            return false;
        }

        public bool DescontarSaldo(float monto)
        {
            if (Saldo - monto >= saldoNegativoPermitido)
            {
                Saldo -= monto;

                if (Saldo < limiteSaldo && saldoPendiente > 0)
                {
                    float espacioDisponible = limiteSaldo - Saldo;
                    float montoAAgregar = Math.Min(espacioDisponible, saldoPendiente);

                    Saldo += montoAAgregar;
                    saldoPendiente -= montoAAgregar;

                }

                return true;
            }

            return false;
        }

        public virtual float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase;
        }
    }
}