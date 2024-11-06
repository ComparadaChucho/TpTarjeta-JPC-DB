using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class testsTarjeta

    {
        public Tarjeta tarjeta;
        public TiempoFalso tiempoFalso;
        public Colectivo colectivo;

        [SetUp]
        public void Setup()
        {
            tarjeta = new Tarjeta(0, 564987, tiempoFalso);
            colectivo = new Colectivo("102");
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
        public void Saldo_De_La_Tarjeta()
        {
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(9000);
            tarjeta.CargarSaldo(2000);

            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(36000));
            Assert.That(tarjeta.saldoPendiente, Is.EqualTo(2000));

            tarjeta.DescontarSaldo(2000);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(36000));
            Assert.That(tarjeta.saldoPendiente, Is.EqualTo(0));
        }

        [Test]
        public void Boleto_de_uso_Frecuente()
        {
            Tarjeta tarjeta = new Tarjeta(0, 564386, tiempoFalso);

            //Primeros 29 viajes Tarifa normal
            for (int i = 0; i < 29; i++)
            {
                tarjeta.CargarSaldo(2000);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
                tarjeta.DescontarSaldo(800);
            }

            //30 al 79 20% de descuento
            for (int j = 0; j < 50; j++)
            {
                tarjeta.CargarSaldo(2000);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1040));
                tarjeta.DescontarSaldo(1040);
            }

            //Viaje 80 25% de descuento
            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1100));
            tarjeta.DescontarSaldo(1100);

            //Viaje 81 en adelante Tarifa normal
            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
            tarjeta.DescontarSaldo(800);

            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
            tarjeta.DescontarSaldo(800);

            //Pasa 1 mes y se reinician los beneficios de uso frecuente

            tiempoFalso.AgregarDias(30);

            //Primeros 29 viajes Tarifa normal
            for (int i = 0; i < 29; i++)
            {
                tarjeta.CargarSaldo(2000);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
                tarjeta.DescontarSaldo(800);
            }

            //30 al 79 20% de descuento
            for (int j = 0; j < 50; j++)
            {
                tarjeta.CargarSaldo(2000);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1040));
                tarjeta.DescontarSaldo(1040);
            }

            //Viaje 80 25% de descuento
            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1100));
            tarjeta.DescontarSaldo(1100);

            //Viaje 81 en adelante Tarifa normal
            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
            tarjeta.DescontarSaldo(800);

            tarjeta.CargarSaldo(2000);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(800));
            tarjeta.DescontarSaldo(800);
        }
    }
}