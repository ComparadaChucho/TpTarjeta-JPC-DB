using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion4

    {
        public Tarjeta tarjeta;
        public Colectivo colectivo, interurbano;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tiempoFalso = new TiempoFalso();
            tarjeta = new Tarjeta(0, 564987, tiempoFalso);
            colectivo = new Colectivo("102", false);
            interurbano = new Colectivo("35/9 N", true);
        }

        [Test]
        public void Lineas_Interurbanas()
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(0, 123, tiempoFalso);
            MedioBoleto medioBoleto = new MedioBoleto(0, 123, tiempoFalso);

            tiempoFalso.AgregarMinutos(360);

            tarjeta.CargarSaldo(4000);
            medioBoleto.CargarSaldo(4000);
            franquicia.CargarSaldo(4000);

            interurbano.PagarCon(tarjeta);
            interurbano.PagarCon(medioBoleto);
            interurbano.PagarCon(franquicia);

            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(1500));
            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(2750));
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(4000));
        }

        [Test]
        public void Franquicias() 
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(0, 123, tiempoFalso);
            MedioBoleto medioBoleto = new MedioBoleto(0, 123, tiempoFalso);

            medioBoleto.CargarSaldo(9000);
            franquicia.CargarSaldo(9000);

            //Son las 00:00:00 de un lunes, cobra tarifa normal
            colectivo.PagarCon(medioBoleto);
            colectivo.PagarCon(franquicia);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(7800));
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(7800));

            tiempoFalso.AgregarMinutos(360);

            //Son las 06:00:00 de un lunes, cobra tarifa con beneficio
            colectivo.PagarCon(medioBoleto);
            colectivo.PagarCon(franquicia);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(7200));
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(7800));

            tiempoFalso.AgregarDias(-1);

            //Son las 06:00:00 pero es Domingo, cobra tarifa normal
            colectivo.PagarCon(medioBoleto);
            colectivo.PagarCon(franquicia);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(6000));
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(6600));
        }
        [Test]
        public void Boleto_de_uso_Frecuente()
        {
            //Primeros 29 viajes Tarifa normal
            for (int i = 1; i <= 29; i++)
            {
                tarjeta.CargarSaldo(1200);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(0));
            }

            //30 al 79 20% de descuento
            for (int i = 1; i >= 49; i++)
            {
                tarjeta.CargarSaldo(960);
                colectivo.PagarCon(tarjeta);
                Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(0));
            }

            //Viaje 80 25% de descuento
            tarjeta.CargarSaldo(900);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(0));

            //Viaje 81 en adelante Tarifa normal
            tarjeta.CargarSaldo(1200);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(0));

            tarjeta.CargarSaldo(1200);
            colectivo.PagarCon(tarjeta);
            Assert.That(tarjeta.ObtenerSaldo(), Is.EqualTo(0));
        }
    }
}