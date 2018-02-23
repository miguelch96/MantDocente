using System;
using System.Threading;
using MantDocente.Tests.SeleniumPages;
using MantDocente.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MantDocente.Tests.SeleniumTests
{
    [TestFixture]
    public class DocenteDeleteWebDriverTest
    {
        private DocenteDeletePage docenteDeletePage;
        private LoginPage loginPage;

        /*private int RowCount=ExcelHelper.NumRowsDelete();*/
        private int RowCount=3;

        [Test]
        public void DeleteDocenteTests()
        {
            for (int i = 2; i <= RowCount; i++)
            {
                DeleteTest("firefox", false,i);
                Thread.Sleep(500);
                /*AddTest("firefox", false, i);
                Thread.Sleep(1000);*/
                /*AddTest("iexplorer", false, i);
                Thread.Sleep(1000);*/
            }



        }

        public void DeleteTest(String navegador, bool remoto,int row)
        {
            try
            {
                loginPage = new LoginPage(navegador, Elements.URL_INICIAL, remoto);
                docenteDeletePage = new DocenteDeletePage(navegador, loginPage.GetWebDriver());

                loginPage.Login("admin", "admin");

                var valores = ExcelHelper.LeerExcelEliminar(row);
                String valorObtenido = docenteDeletePage.Delete(valores["Check"]);
                docenteDeletePage.CerrarPagina();
                Assert.IsTrue(valorObtenido== valores["ValorEsperado"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                docenteDeletePage.CerrarPagina();
                Assert.Fail();
            }

        }
    }
}
