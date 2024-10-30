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
    }
}