using System;
using System.Threading;
using MantDocente.Tests;
using MantDocente.Tests.SeleniumPages;
using MantDocente.Tests.Util;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MantDocenteSelenium.Tests.SeleniumTests
{
    [TestFixture]
    public class DocenteAddWebDriverTest
    {
        private DocenteAddPage docenteAddPage;
        private LoginPage loginPage;

        /*private int RowCount = ExcelHelper.NumRowsAdd();*/
        private int RowCount = 4;


        [Test]
        public void AddDocenteTests()
        {
            for (int i = 2; i <= RowCount; i++)
            {
                AddTest("chrome", false, i);
                Thread.Sleep(1000);
                /*AddTest("firefox", false, i);
                Thread.Sleep(1000);*/
                /*AddTest("iexplorer", false, i);
                Thread.Sleep(1000);*/
            }
            
        }

        public void AddTest(String navegador, bool remoto, int row)
        {
            try
            {
                loginPage = new LoginPage(navegador, Elements.URL_INICIAL, remoto);
                docenteAddPage = new DocenteAddPage(navegador, loginPage.GetWebDriver());
                loginPage.Login("admin", "admin");

                var valores = ExcelHelper.LeerExcelAdd(row);
                String valorObtenido = docenteAddPage.Add(valores["Nombre"].Trim(), valores["Apellido"].Trim(),
                    valores["FechaNacimiento"].Trim(), valores["TipoDoc"].Trim(), valores["NroDoc"].Trim());
                docenteAddPage.CerrarPagina();
                Assert.IsTrue(valorObtenido == valores["ValorEsperado"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                docenteAddPage.CerrarPagina();
                Assert.Fail();
            }
        }

    }
}