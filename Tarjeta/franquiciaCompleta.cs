using System;

namespace TP
{
    public class FranquiciaCompleta : Tarjeta
    {
        private List<DateTime> viajesRealizados;
        private Tiempo tiempo;

        public FranquiciaCompleta(float saldoInicial, int idTarjeta, Tiempo tiempo) : base(saldoInicial, idTarjeta, tiempo) {
            viajesRealizados = new List<DateTime>();
            this.tiempo = tiempo;
        }

        public override float CalcularTarifa(float tarifaBase)
        {
            DateTime hoy = tiempo.Now().Date;
            int viajesHoy = viajesRealizados.Count(fecha => fecha.Date == hoy);

            if (viajesHoy < 2 && tiempo.Now().Hour >= 6 && tiempo.Now().Hour <= 22 && tiempo.Now().DayOfWeek != DayOfWeek.Sunday && tiempo.Now().DayOfWeek != DayOfWeek.Saturday)
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