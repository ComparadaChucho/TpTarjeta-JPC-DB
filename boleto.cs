using System;

namespace TP
{
    public class Boleto
    {
        public float Tarifa;
        public DateTime Fecha;
        public string TipoTarjeta;
        public string LineaColectivo;
        public float SaldoRestante;
        public int IdTarjeta;

        public Boleto(float tarifa, string tipoTarjeta, string lineaColectivo, float saldoRestante, int idTarjeta)
        {
            this.Tarifa = tarifa;
            this.Fecha = DateTime.Now; 
            this.TipoTarjeta = tipoTarjeta;
            this.LineaColectivo = lineaColectivo;
            this.SaldoRestante = saldoRestante;
            this.IdTarjeta = idTarjeta;
        }
    
        public void MostrarBoleto(){
            Console.WriteLine("Tarifa: " + Tarifa);
            Console.WriteLine("Fecha: " + Fecha);
            Console.WriteLine("Tipo de Tarjeta: " + TipoTarjeta);
            Console.WriteLine("Linea: " + LineaColectivo);
            Console.WriteLine("Saldo Restante: " + SaldoRestante);
            Console.WriteLine("Id de la Tarjeta: " + IdTarjeta);
        }
    }
}