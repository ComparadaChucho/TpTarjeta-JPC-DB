using System;

namespace TP{
    
    public class MedioBoleto : Tarjeta
    {
        public MedioBoleto(float saldoInicial) : base(saldoInicial) { }

        public override float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase / 2;
        }
    }
}