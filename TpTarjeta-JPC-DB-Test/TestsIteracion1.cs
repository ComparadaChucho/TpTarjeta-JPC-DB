using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion1

    {
        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987, tiempoFalso);
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        public void Iteracion_1()
        {
            tarjeta.CargarSaldo(2000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(2000));

            tarjeta.DescontarSaldo(2000);

            tarjeta.CargarSaldo(3000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(3000));

            tarjeta.DescontarSaldo(3000);

            tarjeta.CargarSaldo(4000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(4000));

            tarjeta.DescontarSaldo(4000);

            tarjeta.CargarSaldo(5000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(5000));

            tarjeta.DescontarSaldo(5000);

            tarjeta.CargarSaldo(6000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(6000));

            tarjeta.DescontarSaldo(6000);

            tarjeta.CargarSaldo(7000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(7000));

            tarjeta.DescontarSaldo(7000);

            tarjeta.CargarSaldo(8000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(8000));

            tarjeta.DescontarSaldo(8000);

            tarjeta.CargarSaldo(9000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(9000));
        }
    }
}