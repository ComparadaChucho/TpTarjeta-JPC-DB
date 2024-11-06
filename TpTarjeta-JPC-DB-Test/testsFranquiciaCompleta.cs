using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class testsFranquiciaCompleta

    {
        public TiempoFalso tiempoFalso;
        public Colectivo colectivo;

        [SetUp]
        public void Setup()
        {
            colectivo = new Colectivo("102");
            tiempoFalso = new TiempoFalso();
        }

        [Test]
        public void Franquicia_De_Boleto()
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(0, 123, tiempoFalso);
            
            tiempoFalso.AgregarMinutos(500);

            franquicia.CargarSaldo(2000);
            colectivo.PagarCon(franquicia);
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(2000));
        }

        [Test]
        public void Limitacion_En_El_Pago_Franquicias_Completas()
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(1000, 123, tiempoFalso);

            tiempoFalso.AgregarMinutos(360);

            float tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            //Se quedo sin viajes gratuitos, cobra tarifa normal
            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));

            tiempoFalso.AgregarDias(1);

            //Paso 1 dia, tiene 2 boletos gratuitos
            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(0, Is.EqualTo(tarifa));

            //Se quedo sin viajes gratuitos, cobra tarifa normal
            tarifa = franquicia.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));
        }

        [Test]
        public void Franja_Horaria()
        {
            FranquiciaCompleta franquicia = new FranquiciaCompleta(0, 123, tiempoFalso);

            franquicia.CargarSaldo(9000);

            //Son las 00:00:00 de un lunes, cobra tarifa normal
            colectivo.PagarCon(franquicia);

            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(7800));

            tiempoFalso.AgregarMinutos(360);

            //Son las 06:00:00 de un lunes, cobra tarifa con beneficio
            colectivo.PagarCon(franquicia);

            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(7800));

            tiempoFalso.AgregarDias(-1);

            //Son las 06:00:00 pero es Domingo, cobra tarifa normal
            colectivo.PagarCon(franquicia);

            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(6600));
        }
    }
}