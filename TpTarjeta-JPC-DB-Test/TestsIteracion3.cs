using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion3

    {
        public Tarjeta tarjeta;
        public Colectivo colectivo;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987);
            colectivo = new Colectivo("102");
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        public void Saldo_De_La_Tarjeta()
        {
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(2000);

            Assert.That(tarjeta.Saldo, Is.EqualTo(36000));
            Assert.That(tarjeta.saldoPendiente, Is.EqualTo(2000));

            tarjeta.DescontarSaldo(2000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(36000));
            Assert.That(tarjeta.saldoPendiente, Is.EqualTo(0));
        }

        [Test]
        public void Limitacion_En_El_Pago_Franquicias_Completas()
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(1000, 123, tiempoFalso);

            float tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));

            tiempoFalso.AgregarDias(1);

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));
        }

        [Test]
        public void Limitacion_En_El_Pago_Medio_Boleto()
        {
            MedioBoleto medioBoleto = new MedioBoleto(1000, 123, tiempoFalso);

            float tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.IsFalse(tarifa == 470);

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));

            tiempoFalso.AgregarDias(1);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));
        }
    }
}