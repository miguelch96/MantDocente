using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MantDocente.Tests.SeleniumPages.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantDocente.Tests.SeleniumPages
{
    class DocenteListarPage
    {
        private IWebDriver webDriver;

        public DocenteListarPage(String navegador, bool remoto)
        {
            webDriver = DocenteDriver.InicializarDriver(navegador, remoto);
        }

        public DocenteListarPage(String navegador, IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String Listar()
        {
            Thread.Sleep(1000);

            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(wt => wt.FindElement(Elements.btnAgregar));

            return webDriver.FindElement(Elements.divMainList).Text;
    
        }

        public void CerrarPagina()
        {
            DocenteDriver.CerrarPagina(webDriver);
        }

        public IWebDriver GetWebDriver()
        {
            return webDriver;
        }
    }
}