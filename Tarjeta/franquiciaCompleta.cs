using System;

namespace TP
{
    public class FranquiciaCompleta : Tarjeta
    {
        public FranquiciaCompleta(float saldoInicial, int idTarjeta) : base(saldoInicial, idTarjeta) { }

        public override float CalcularTarifa(float tarifaBase)
        {
            return 0;
        }
    }
}