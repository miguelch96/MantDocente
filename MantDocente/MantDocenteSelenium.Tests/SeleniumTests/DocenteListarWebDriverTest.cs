using System;
using System.Threading;
using MantDocente.Tests.SeleniumPages;
using MantDocente.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace MantDocente.Tests.SeleniumTests
{
    [TestFixture]
    public class DocenteListarWebDriverTest
    {
        private DocenteListarPage docenteListarPage;
        private LoginPage loginPage;
        private int rowsCount=2;
        [Test]
        public void ListarDocentesTest()
        {
            for (int i = 2; i <= rowsCount; i++)
            {
                ListTest("chrome", false,i);
                Thread.Sleep(500);
                /*AddTest("firefox", false, i);
                Thread.Sleep(1000);*/
                /*AddTest("iexplorer", false, i);
                Thread.Sleep(1000);*/
            }




        }

        public void ListTest(String navegador, bool remoto,int row)
        {
            try
            {
                loginPage = new LoginPage(navegador, Elements.URL_INICIAL, remoto);
                docenteListarPage = new DocenteListarPage(navegador, loginPage.GetWebDriver());

                loginPage.Login("admin", "admin");

                var valores = ExcelHelper.LeerExcelListar(row);
                String valorObtenido = docenteListarPage.Listar();
                docenteListarPage.CerrarPagina();
                Assert.IsTrue(valorObtenido==valores["ValorEsperado"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                docenteListarPage.CerrarPagina();
                Assert.Fail();
            }

        }
    }
}
