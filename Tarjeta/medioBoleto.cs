using System;
using System.Runtime.CompilerServices;

namespace TP
{
    public class MedioBoleto : Tarjeta
    {
        private List<DateTime> viajesRealizados;
        private Tiempo tiempo;

        public MedioBoleto(float saldoInicial, int idTarjeta, Tiempo tiempo) : base(saldoInicial, idTarjeta)
        {
            viajesRealizados = new List<DateTime>();
            this.tiempo = tiempo;
        }

        public override float CalcularTarifa(float tarifaBase)
        {
            DateTime hoy = tiempo.Now().Date;
            int viajesHoy = viajesRealizados.Count(fecha => fecha.Date == hoy);
            var ultimoViaje = viajesRealizados.LastOrDefault();

            if (viajesHoy < 4 && cincoMinutos(ultimoViaje, tiempo) && tiempo.Now().Hour >= 6 && tiempo.Now().Hour <= 22 && tiempo.Now().DayOfWeek != DayOfWeek.Sunday && tiempo.Now().DayOfWeek != DayOfWeek.Saturday)
            {
                viajesRealizados.Add(tiempo.Now());
                return tarifaBase / 2;
            }
            else
            {
                return tarifaBase;
            }
        }

        private bool cincoMinutos(DateTime ultimoViaje, Tiempo tiempo)
        {
            TimeSpan dif = tiempo.Now() - ultimoViaje;
            if (dif.TotalMinutes > 5)
            {
                return true;
            }

            return false;
        }
    }
}