using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion3

    {
        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987);
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
            TiempoFalso tiempoFalso = new TiempoFalso();
            FranquiciaCompleta tarjeta = new FranquiciaCompleta(1000, 123, tiempoFalso);
            Colectivo colectivo = new Colectivo("102");

            float tarifa1 = tarjeta.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa1));

            float tarifa2 = tarjeta.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa2));

            float tarifa3 = tarjeta.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa3));

            tiempoFalso.AgregarDias(1);

            float tarifaNueva1 = tarjeta.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifaNueva1));

            float tarifaNueva2 = tarjeta.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifaNueva2));

            float tarifaNueva3 = tarjeta.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifaNueva3));
        }

    }
}