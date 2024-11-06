using NUnit.Framework;
using TP;

namespace TpTarjeta_JPC_DB_Test
{
    public class testsMedioBoleto

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
            MedioBoleto medioBoleto = new MedioBoleto(0, 123, tiempoFalso);

            tiempoFalso.AgregarMinutos(500);

            medioBoleto.CargarSaldo(2000);
            colectivo.PagarCon(medioBoleto);
            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(1400));
        }

        [Test]
        public void Limitacion_En_El_Pago_Medio_Boleto()
        {
            MedioBoleto medioBoleto = new MedioBoleto(1000, 123, tiempoFalso);

            tiempoFalso.AgregarMinutos(360);

            float tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            //Como no pasaron mas de 5 minutos cobra tarifa normal
            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.IsFalse(tarifa == 470);

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            //Pasaron mas de 5 minutos pero se quedo sin viajes con medio Boleto, cobra tarifa normal
            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));

            tiempoFalso.AgregarDias(1);

            //Paso 1 dia, por lo tanto, tiene 4 medio boleto para utilizar
            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(470, Is.EqualTo(tarifa));

            tiempoFalso.AgregarMinutos(6);

            //Pasaron mas de 5 minutos pero se quedo sin viajes con medio Boleto, cobra tarifa normal
            tarifa = medioBoleto.CalcularTarifa(940);
            Assert.That(940, Is.EqualTo(tarifa));
        }

        [Test]
        public void Franja_Horaria()
        {
            MedioBoleto medioBoleto = new MedioBoleto(0, 123, tiempoFalso);

            medioBoleto.CargarSaldo(9000);

            //Son las 00:00:00 de un lunes, cobra tarifa normal
            colectivo.PagarCon(medioBoleto);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(7800));

            tiempoFalso.AgregarMinutos(360);

            //Son las 06:00:00 de un lunes, cobra tarifa con beneficio
            colectivo.PagarCon(medioBoleto);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(7200));

            tiempoFalso.AgregarDias(-1);

            //Son las 06:00:00 pero es Domingo, cobra tarifa normal
            colectivo.PagarCon(medioBoleto);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(6000));
        }
    }
}