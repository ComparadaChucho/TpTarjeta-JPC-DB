using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class TestsIteracion4

    {
        public Tarjeta tarjeta;
        public Colectivo colectivo, interurbano;
        public MedioBoleto medioboleto;
        public FranquiciaCompleta franquicia;
        public TiempoFalso tiempoFalso;

        [SetUp]
        public void Setup()
        {
            tiempoFalso = new TiempoFalso();
            tarjeta = new Tarjeta(0, 564987);
            medioboleto = new MedioBoleto(0, 4863856, tiempoFalso);
            franquicia = new FranquiciaCompleta(0, 5757683, tiempoFalso);
            colectivo = new Colectivo("102", false);
            interurbano = new Colectivo("35/9 N", true);
        }

        [Test]
        public void Lineas_Interurbanas()
        {
            tarjeta.CargarSaldo(4000);
            medioboleto.CargarSaldo(4000);
            franquicia.CargarSaldo(4000);

            interurbano.PagarCon(tarjeta);
            interurbano.PagarCon(medioboleto);
            interurbano.PagarCon(franquicia);

            Assert.That(tarjeta.Saldo, Is.EqualTo(1500));
            Assert.That(medioboleto.Saldo, Is.EqualTo(2750));
            Assert.That(franquicia.Saldo, Is.EqualTo(4000));
        }
    }
}