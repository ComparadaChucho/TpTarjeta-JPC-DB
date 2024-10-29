using System;

namespace TP
{
    public class Tarjeta
    {
        public float Saldo { get; protected set; }
        public int idTarjeta;
        private float saldoPendiente = 0;
        private float limiteSaldo = 36000;
        private float saldoNegativoPermitido = -480;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        public Tarjeta(float saldoInicial, int id)
        {
            Saldo = saldoInicial;
            this.idTarjeta = id;
            Console.WriteLine($"Tarjeta creada con: ${Saldo}, ID {idTarjeta}");
        }

        public float ObtenerSaldo()
        {
            Console.WriteLine($"Saldo: ${Saldo}");
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
                Console.WriteLine($"Se descontó ${monto}. Saldo actual: ${Saldo}");

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

            Console.WriteLine($"Saldo insuficiente para realizar la operacion. Saldo: ${Saldo}, Tarifa: ${monto}");
            return false;
        }

        public virtual float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase;
        }
    }
}