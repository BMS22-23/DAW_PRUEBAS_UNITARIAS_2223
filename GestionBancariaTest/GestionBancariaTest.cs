using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void ValidarReintegroSinErr()
        {
            double[] saldosIniciales = { 30, 30, 30, 61, 900, 1000 };
            double[] reintegros = { 1, 2, 30, 60, 90, 250 };
            int salidaEsperada = GestionBancariaApp.SIN_ERR;

            for (int i = 0; i < saldosIniciales.Length; i++)
            {
                double saldoInicial = saldosIniciales[i];
                double reintegro = reintegros[i];
                double saldoEsperado = saldoInicial - reintegro;

                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                // Método a probar
                int salida = miApp.RealizarReintegro(reintegro);
                Assert.AreEqual(salidaEsperada, salida, "Salida incorrecta.");
                Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo" +
                "incorrecto.");
            }
        }

        [TestMethod]
        public void ValidarReintegroSaldoInsuficiente()
        {
            double[] saldosIniciales = { 0, 1, 28, 59, 88, 240 };
            double[] reintegros = { 1, 2, 30, 60, 90, 250 };

            for (int i = 0; i < saldosIniciales.Length; i++)
            {
                double saldoInicial = saldosIniciales[i];
                double reintegro = reintegros[i];

                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.RealizarReintegro(reintegro);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                    Assert.AreEqual(saldoInicial, miApp.ObtenerSaldo(), 0.001,
                        "El saldo no debería cambiar.");
                    return;
                }
                Assert.Fail("Error. Se debía haber producido una excepción.");
            }
        }

        [TestMethod]
        public void ValidarReintegroCantidadNoValida()
        {
            double[] saldosIniciales = { 30, 30, 30, 61, 900, 1000 };
            double[] reintegros = { -2, -1, 0, -30, -60, -900 };

            for (int i = 0; i < saldosIniciales.Length; i++)
            {
                double saldoInicial = saldosIniciales[i];
                double reintegro = reintegros[i];

                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.RealizarReintegro(reintegro);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                    Assert.AreEqual(saldoInicial, miApp.ObtenerSaldo(), 0.001,
                        "El saldo no debería cambiar.");
                    return;
                }
                Assert.Fail("Error. Se debía haber producido una excepción.");
            }
        }

        [TestMethod]
        public void ValidarIngreso()
        {
            double[] ingresos = { 1, 2, 30, 900 };
            int salidaEsperada = GestionBancariaApp.SIN_ERR;
            double saldoInicial = 30;

            for (int i = 0; i < ingresos.Length; i++)
            {
                double ingreso = ingresos[i];
                double saldoEsperado = saldoInicial + ingreso;

                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                // Método a probar
                int salida = miApp.RealizarIngreso(ingreso);
                Assert.AreEqual(salidaEsperada, salida, "Salida incorrecta.");
                Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo" +
                "incorrecto.");
            }
        }

        [TestMethod]
        public void ValidarIngresoCantidadNoValida()
        {
            double saldoInicial = 30;
            double[] ingresos = { -2, -1, 0, -30, -900 };

            for (int i = 0; i < ingresos.Length; i++)
            {
                double ingreso = ingresos[i];

                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.RealizarIngreso(ingreso);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                    Assert.AreEqual(saldoInicial, miApp.ObtenerSaldo(), 0.001,
                        "El saldo no debería cambiar.");
                    return;
                }
                Assert.Fail("Error. Se debía haber producido una excepción.");
            }
        }
    }
}
