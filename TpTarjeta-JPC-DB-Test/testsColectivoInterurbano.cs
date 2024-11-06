using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class testsColectivoInterurbano

    {
        public Tarjeta tarjeta;
        public Interurbano interurbano;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tiempoFalso = new TiempoFalso();
            tarjeta = new Tarjeta(0, 564987, tiempoFalso);
            interurbano = new Interurbano("35/9 N");
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
    }
}