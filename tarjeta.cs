using System;

namespace TP
{
    public class Tarjeta
    {
        public float Saldo { get; protected set; }
        private float limiteSaldo = 9900;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        private float saldoNegativoPermitido = -480;

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
            if (Array.Exists(cargasAceptadas, carga => carga == monto) && (Saldo + monto <= limiteSaldo))
            {
                Saldo += monto;

                Console.WriteLine($"Saldo cargado: ${monto}. Saldo: ${Saldo}");

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
                return true;
            }

            Console.WriteLine($"Saldo insuficiente para realizar la operación. Saldo: ${Saldo}, Tarifa: ${monto}");
            return false;
        }


    }

}