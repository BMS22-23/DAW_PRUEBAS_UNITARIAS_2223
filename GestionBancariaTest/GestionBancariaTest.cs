﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void ValidarReintegro()
        {
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }
        [TestMethod]
        public void ValidarReintegro1()
        {
            double saldoInicial = 30;
            double reintegro = 1;
            double saldoEsperado = saldoInicial - reintegro;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro2()
        {
            double saldoInicial = 30;
            double reintegro = 2;
            double saldoEsperado = saldoInicial - reintegro;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro3()
        {
            double saldoInicial = 30;
            double reintegro = 30;
            double saldoEsperado = saldoInicial - reintegro;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro4()
        {
            double saldoInicial = 31;
            double reintegro = 30;
            double saldoEsperado = saldoInicial - reintegro;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro5()
        {
            double saldoInicial = 60;
            double reintegro = 30;
            double saldoEsperado = saldoInicial - reintegro;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroSaldoInsuficienteCaso1()
        {
            double saldoInicial = 29;
            double reintegro = 30;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroSaldoInsuficienteCaso2()
        {
            double saldoInicial = 15;
            double reintegro = 30;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNoValidaCaso1()
        {
            double saldoInicial = 30;
            double reintegro = -1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNoValidaCaso2()
        {
            double saldoInicial = 30;
            double reintegro = 0;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNoValidaCaso3()
        {
            double saldoInicial = 30;
            double reintegro = -30;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarReintegro(reintegro);
        }
        private static void ProbarReintegro(double saldoInicial, double reintegro, double saldoEsperado, int salidaEsperada)
        {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            int salida = miApp.RealizarReintegro(reintegro);
            Assert.AreEqual(salidaEsperada, salida, "Salida incorrecta.");
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }



        [TestMethod]
        public void ValidarIngreso1()
        {
            double saldoInicial = 30;
            double ingreso = 1;
            double saldoEsperado = saldoInicial + ingreso;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarIngreso2()
        {
            double saldoInicial = 30;
            double ingreso = 2;
            double saldoEsperado = saldoInicial + ingreso;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarIngreso3()
        {
            double saldoInicial = 30;
            double ingreso = 30;
            double saldoEsperado = saldoInicial + ingreso;
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNoValidaCaso1()
        {
            double saldoInicial = 30;
            double ingreso = -1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarIngreso(ingreso);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNoValidaCaso2()
        {
            double saldoInicial = 30;
            double ingreso = 0;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarIngreso(ingreso);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNoValidaCaso3()
        {
            double saldoInicial = 30;
            double ingreso = -30;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            miApp.RealizarIngreso(ingreso);
        }
        private static void ProbarIngreso(double saldoInicial, double ingreso, double saldoEsperado, int salidaEsperada)
        {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            // Método a probar
            int salida = miApp.RealizarIngreso(ingreso);
            Assert.AreEqual(salidaEsperada, salida, "Salida incorrecta.");
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
            "Se produjo un error al realizar el ingreso, saldo" +
            "incorrecto.");
        }
    }
}
