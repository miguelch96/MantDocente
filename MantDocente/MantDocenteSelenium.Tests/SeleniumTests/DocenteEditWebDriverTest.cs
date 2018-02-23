using System;
using System.Threading;
using MantDocente.Tests.SeleniumPages;
using MantDocente.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MantDocente.Tests.SeleniumTests
{
    [TestFixture]
    public class DocenteEditWebDriverTest
    {
        private DocenteEditPage docenteEditPage;
        private LoginPage loginPage;

        /*private int RowCount = ExcelHelper.NumRowsEdit();*/
        private int RowCount = 4;

        [Test]
        public void EditDocenteTests()
        {
            for (int i = 4; i <= RowCount; i++)
            {
                EditTest("firefox", false,i);
                Thread.Sleep(1500);
                /*AddTest("firefox", false, i);
                Thread.Sleep(1000);*/
                /*AddTest("iexplorer", false, i);
                Thread.Sleep(1000);*/
            }

        }

        public void EditTest(String navegador,bool remoto,int row)
        {
            try
            {
                loginPage = new LoginPage(navegador, Elements.URL_INICIAL, remoto);
                docenteEditPage = new DocenteEditPage(navegador, loginPage.GetWebDriver());
                loginPage.Login("admin", "admin");

                var valores = ExcelHelper.LeerExcelEdit(row);
                String valorObtenido = docenteEditPage.Edit(valores["Nombre"].Trim(), valores["Apellido"].Trim(), valores["TipoDoc"].Trim());
                docenteEditPage.CerrarPagina();
                Assert.IsTrue(valorObtenido== valores["ValorEsperado"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                docenteEditPage.CerrarPagina();
                Assert.Fail();
            }
            
        }

        
    }
}
