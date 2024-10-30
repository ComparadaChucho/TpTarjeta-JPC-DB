using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class Tests_Franquicias

    {
        public Colectivo colectivo;
        public MedioBoleto medioboleto;
        public FranquiciaCompleta franquicia;


        [SetUp]
        public void Setup()
        {
            colectivo = new Colectivo("102");
            medioboleto = new MedioBoleto(0, 4863856);
            franquicia = new FranquiciaCompleta(0, 5757683);

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