using System;

namespace TP
{
    public class FranquiciaCompleta : Tarjeta
    {
        private List<DateTime> viajesRealizados;
        private Tiempo Tiempo;

        public FranquiciaCompleta(float saldoInicial, int idTarjeta, Tiempo Tiempo) : base(saldoInicial, idTarjeta) {
            viajesRealizados = new List<DateTime>();
            this.Tiempo = Tiempo;
        }

        public override float CalcularTarifa(float tarifaBase)
        {
            DateTime hoy = Tiempo.Now().Date;
            int viajesHoy = viajesRealizados.Count(fecha => fecha.Date == hoy);

            if (viajesHoy < 2)
            {
                viajesRealizados.Add(Tiempo.Now());
                return 0;
            }
            else
            {
                return tarifaBase;
            }
        }
    }
}