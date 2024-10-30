using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion2

    {
        public Tarjeta tarjeta;
        public Colectivo colectivo;
        public MedioBoleto medioboleto;
        public FranquiciaCompleta franquicia;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987);
            colectivo = new Colectivo("102");
            medioboleto = new MedioBoleto(0, 4863856);
            franquicia = new FranquiciaCompleta(0, 5757683);

        }

        [Test]
        public void Descuento_De_Saldos()
        {
            tarjeta.CargarSaldo(2000);
            Assert.IsTrue(tarjeta.DescontarSaldo(1000));
            Assert.That(tarjeta.Saldo, Is.EqualTo(1000));

            tarjeta.DescontarSaldo(500);

            Assert.IsTrue(tarjeta.DescontarSaldo(980));
            Assert.That(tarjeta.Saldo, Is.EqualTo(-480));
        }

        [Test]
        public void Saldo_Negativo()
        {
            tarjeta.CargarSaldo(2000);
            tarjeta.DescontarSaldo(2480);
            Assert.That(tarjeta.Saldo, Is.EqualTo(-480));

            Assert.IsFalse(tarjeta.DescontarSaldo(10));
            Assert.That(tarjeta.Saldo, Is.EqualTo(-480));

            tarjeta.CargarSaldo(2000);
            Assert.That(tarjeta.Saldo, Is.EqualTo(1520));
        }

        [Test]
        public void Franquicia_De_Boleto()
        {
            medioboleto.CargarSaldo(2000);
            colectivo.PagarCon(medioboleto);
            Assert.That(medioboleto.Saldo, Is.EqualTo(1530));

            franquicia.CargarSaldo(2000);
            colectivo.PagarCon(franquicia);
            Assert.That(franquicia.Saldo, Is.EqualTo(2000));
        }
    }
}