using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class Tests

    {
        public Colectivo colectivo;
        public Tarjeta tarjeta;
        public MedioBoleto medioboleto;
        public FranquiciaCompleta franquicia;


        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0);
            colectivo = new Colectivo();
            medioboleto = new MedioBoleto(0);
            franquicia = new FranquiciaCompleta(0);
            
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

        [Test]
        public void Descuento_saldo()
        {
            tarjeta.CargarSaldo(2000);
            Assert.IsTrue(tarjeta.DescontarSaldo(1000));
            Assert.That(tarjeta.Saldo, Is.EqualTo(1000));

            tarjeta.DescontarSaldo(500);

            Assert.IsTrue(tarjeta.DescontarSaldo(980));
            Assert.That(tarjeta.Saldo, Is.EqualTo(-480));
        }

        [Test]
        public void Saldo_negativo_permitido()
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
        public void Franquicias()
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