﻿using NUnit.Framework;
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
            tarjeta = new Tarjeta(0, 564987);
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

            //Son las 00:00:00 de un lunes, cobra tarifa completa
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

            //Son las 06:00:00 pero es Domingo, cobra tarifa completa
            colectivo.PagarCon(medioBoleto);
            colectivo.PagarCon(franquicia);

            Assert.That(medioBoleto.ObtenerSaldo(), Is.EqualTo(6000));
            Assert.That(franquicia.ObtenerSaldo(), Is.EqualTo(6600));
        }
    }
}