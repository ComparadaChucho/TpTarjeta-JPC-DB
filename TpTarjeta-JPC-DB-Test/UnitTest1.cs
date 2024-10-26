using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class Tests

    {
        public Colectivo colectivo;
        public Tarjeta tarjeta;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0);
            colectivo = new Colectivo();
        }

        [Test]  
        public void Check_saldo()
        {
            tarjeta.CargarSaldo(2000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(2000));

            tarjeta.DescontarSaldo(2000);

            tarjeta.CargarSaldo(3000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(3000));

            tarjeta.DescontarSaldo(3000);

            tarjeta.CargarSaldo(4000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(4000));

            tarjeta.DescontarSaldo(4000);

            tarjeta.CargarSaldo(5000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(5000));

            tarjeta.DescontarSaldo(5000);

            tarjeta.CargarSaldo(6000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(6000));

            tarjeta.DescontarSaldo(6000);

            tarjeta.CargarSaldo(7000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(7000));

            tarjeta.DescontarSaldo(7000);

            tarjeta.CargarSaldo(8000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(8000));

            tarjeta.DescontarSaldo(8000);

            tarjeta.CargarSaldo(9000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(9000));
            
        }
    }
}