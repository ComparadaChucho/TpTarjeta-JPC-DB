using System;

namespace TP {
    public class FranquiciaCompleta : Tarjeta
    {
        public FranquiciaCompleta(float saldoInicial) : base(saldoInicial) { }

        public override float CalcularTarifa(float tarifaBase)
        {    
            return 0;
        }
    }
}