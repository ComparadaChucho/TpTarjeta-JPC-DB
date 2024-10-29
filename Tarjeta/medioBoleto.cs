using System;

namespace TP
{

    public class MedioBoleto : Tarjeta
    {
        public MedioBoleto(float saldoInicial, int idTarjeta) : base(saldoInicial, idTarjeta) { }

        public override float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase / 2;
        }
    }
}