using System;

namespace TP
{
    public class Tarjeta
    {
        public float Saldo { get; protected set; }
        private float saldoPendiente = 0;
        private float limiteSaldo = 36000;
        private float saldoNegativoPermitido = -480;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        public Tarjeta(float saldoInicial = 0)
        {
            Saldo = saldoInicial;
            Console.WriteLine($"Tarjeta creada con: ${Saldo}");
        }

        public float ObtenerSaldo()
        {
            Console.WriteLine($"Saldo: ${Saldo}");
            return Saldo;
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

                    Console.WriteLine($"Se cargaron ${montoCargado} hasta el limite de la tarjeta. Saldo actual: ${Saldo}. Queda pendiente: ${saldoPendiente}");
                    return true;
                }

                Saldo += monto;
                Console.WriteLine($"Saldo cargado: ${monto}. Saldo actual: ${Saldo}");
                return true;
            }

            Console.WriteLine($"Carga fallida. Monto: ${monto}, Límite: ${limiteSaldo}, Saldo: ${Saldo}");
            return false;
        }

        public bool DescontarSaldo(float monto)
        {
            if (Saldo - monto >= saldoNegativoPermitido)
            {
                Saldo -= monto;
                Console.WriteLine($"Se descontó ${monto} de la tarjeta. Saldo actual: ${Saldo}");

                if (Saldo < limiteSaldo && saldoPendiente > 0)
                {
                    float espacioDisponible = limiteSaldo - Saldo;
                    float montoAAgregar = Math.Min(espacioDisponible, saldoPendiente);

                    Saldo += montoAAgregar;
                    saldoPendiente -= montoAAgregar;

                    Console.WriteLine($"Despues de la compra, se acreditaron ${montoAAgregar} del saldo pendiente. Saldo pendiente restante: ${saldoPendiente}. Saldo actual: ${Saldo}");
                }

                return true;
            }

            Console.WriteLine($"Saldo insuficiente para realizar la operación. Saldo: ${Saldo}, Tarifa: ${monto}");
            return false;
        }

        public virtual float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase;
        }
    }


    public class MedioBoleto : Tarjeta
    {
        public MedioBoleto(float saldoInicial = 0) : base(saldoInicial) { }

        public override float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase / 2;
        }
    }

    public class FranquiciaCompleta : Tarjeta
    {
        public FranquiciaCompleta(float saldoInicial = 0) : base(saldoInicial) { }

        public override float CalcularTarifa(float tarifaBase)
        {
            return 0;
        }
    }
}