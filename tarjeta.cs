using System;

namespace TP
{
    public class Tarjeta
    {
        private float saldo;
        private float limiteSaldo = 9900;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

        public Tarjeta(float saldoInicial = 0)
        {
            saldo = saldoInicial;
            Console.WriteLine($"Tarjeta creada con: ${saldoInicial}");
        }

        public float ObtenerSaldo()
        {
            Console.WriteLine($"Saldo: ${saldo}");
            return saldo;
        }

        public bool CargarSaldo(float monto)
        {
            if (Array.Exists(cargasAceptadas, carga => carga == monto) && (saldo + monto <= limiteSaldo))
            {
                saldo += monto;
                Console.WriteLine($"Saldo cargado: ${monto}. Saldo: ${saldo}");
                return true;
            }
            Console.WriteLine($"Carga fallida. Monto: ${monto}, Límite: ${limiteSaldo}, Saldo: ${saldo}");
            return false;
        }

        public bool DescontarSaldo(float monto)
        {
            if (saldo >= monto)
            {
                saldo -= monto;
                Console.WriteLine($"Se descontó ${monto} de la tarjeta. Saldo: ${saldo}");
                return true;
            }
            Console.WriteLine($"Saldo insuficiente. Tarifa: ${monto}. Saldo: ${saldo}");
            return false;
        }
    }
}
