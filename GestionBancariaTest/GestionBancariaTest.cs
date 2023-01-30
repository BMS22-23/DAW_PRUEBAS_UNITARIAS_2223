using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ValidarReintegro6()
        {
            double saldoInicial = 29;
            double reintegro = 30;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_SALDO_INSUFICIENTE;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro7()
        {
            double saldoInicial = 15;
            double reintegro = 30;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_SALDO_INSUFICIENTE;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro8()
        {
            double saldoInicial = 30;
            double reintegro = -1;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro9()
        {
            double saldoInicial = 30;
            double reintegro = 0;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarReintegro10()
        {
            double saldoInicial = 30;
            double reintegro = -30;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarReintegro(saldoInicial, reintegro, saldoEsperado, salidaEsperada);
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
        public void ValidarIngreso4()
        {
            double saldoInicial = 30;
            double ingreso = -1;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarIngreso5()
        {
            double saldoInicial = 30;
            double ingreso = 0;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
        }
        [TestMethod]
        public void ValidarIngreso6()
        {
            double saldoInicial = 30;
            double ingreso = -30;
            double saldoEsperado = saldoInicial;
            int salidaEsperada = GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA;

            ProbarIngreso(saldoInicial, ingreso, saldoEsperado, salidaEsperada);
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
