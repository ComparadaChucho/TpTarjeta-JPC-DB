using System;

namespace TP
{
    public class JubiladoGratuito : Tarjeta
    {
        private List<DateTime> viajesRealizados;
        private Tiempo tiempo;

        public JubiladoGratuito(float saldoInicial, int idTarjeta, Tiempo tiempo) : base(saldoInicial, idTarjeta, tiempo)
        {
            viajesRealizados = new List<DateTime>();
            this.tiempo = tiempo;
        }

        public override float CalcularTarifa(float tarifaBase)
        {
            if (tiempo.Now().Hour >= 6 && tiempo.Now().Hour <= 22 && tiempo.Now().DayOfWeek != DayOfWeek.Sunday && tiempo.Now().DayOfWeek != DayOfWeek.Saturday)
            {
                viajesRealizados.Add(tiempo.Now());
                return 0;
            }
            else
            {
                return tarifaBase;
            }
        }
    }
}