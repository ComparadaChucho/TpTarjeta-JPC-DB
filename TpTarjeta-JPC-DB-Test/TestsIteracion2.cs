using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion2

    {
        public Tarjeta tarjeta;
        public Colectivo colectivo;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987, tiempoFalso);
            colectivo = new Colectivo("102", false);
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        public void Descuento_De_Saldos()
        {
            tarjeta.CargarSaldo(2000);
            Assert.IsTrue(tarjeta.DescontarSaldo(1000));
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1000));

            tarjeta.DescontarSaldo(500);

            Assert.IsTrue(tarjeta.DescontarSaldo(980));
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(-480));
        }

        [Test]
        public void Saldo_Negativo()
        {
            tarjeta.CargarSaldo(2000);
            tarjeta.DescontarSaldo(2480);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(-480));

            Assert.IsFalse(tarjeta.DescontarSaldo(10));
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(-480));

            tarjeta.CargarSaldo(2000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1520));
        }

        [Test]
        public void Franquicia_De_Boleto()
        {
            MedioBoleto medioBoleto = new MedioBoleto(0, 123, tiempoFalso);

            tiempoFalso.AgregarMinutos(500);

            medioBoleto.CargarSaldo(2000);
            colectivo.PagarCon(medioBoleto);
            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(1400));

            FranquiciaCompleta franquicia = new FranquiciaCompleta(0, 123, tiempoFalso);

            franquicia.CargarSaldo(2000);
            colectivo.PagarCon(franquicia);
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(2000));
        }
    }
}