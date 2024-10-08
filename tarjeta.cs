using System;

namespace TP
{
    public class Tarjeta
    {
        public float Saldo;
        public int idTarjeta;
        private float limiteSaldo = 9900;
        private float[] cargasAceptadas = { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };
        private float saldoNegativoPermitido = -480;

        public Tarjeta(float saldoInicial, int id)
        {
            this.Saldo = saldoInicial;
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

        public virtual float CalcularTarifa(float tarifaBase)
        {
            return tarifaBase;
        }
    }

        public class MedioBoleto : Tarjeta
        {
            public MedioBoleto(float saldoInicial, int idTarjeta) : base(saldoInicial, idTarjeta) { }
            
            public override float CalcularTarifa(float tarifaBase)
            {
                return tarifaBase / 2;
            }
        }

        public class FranquiciaCompleta : Tarjeta
        {
            public FranquiciaCompleta(float saldoInicial, int idTarjeta) : base(saldoInicial, idTarjeta) { }

            public override float CalcularTarifa(float tarifaBase)
            {
                return 0;
            }
        }
    }