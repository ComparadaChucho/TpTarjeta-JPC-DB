using System;
using System.Runtime.CompilerServices;

namespace TP
{
    public class MedioBoleto : Tarjeta
    {
        private List<DateTime> viajesRealizados;
        private Tiempo Tiempo;

        public MedioBoleto(float saldoInicial, int idTarjeta, Tiempo Tiempo) : base(saldoInicial, idTarjeta)
        {
            viajesRealizados = new List<DateTime>();
            this.Tiempo = Tiempo;
        }

        public override float CalcularTarifa(float tarifaBase)
        {
            DateTime hoy = Tiempo.Now().Date;
            int viajesHoy = viajesRealizados.Count(fecha => fecha.Date == hoy);
            var ultimoViaje = viajesRealizados.LastOrDefault();

            if (viajesHoy < 4 && cincoMinutos(ultimoViaje, Tiempo))
            {
                viajesRealizados.Add(Tiempo.Now());
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