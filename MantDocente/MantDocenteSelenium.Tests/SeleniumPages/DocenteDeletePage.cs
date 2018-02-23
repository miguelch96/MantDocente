using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MantDocente.Tests.SeleniumPages.Driver;
using OpenQA.Selenium;

namespace MantDocente.Tests.SeleniumPages
{
    class DocenteDeletePage
    {
        private IWebDriver webDriver;

        public DocenteDeletePage(String navegador, bool remoto)
        {
            webDriver = DocenteDriver.InicializarDriver(navegador, remoto);
        }

        public DocenteDeletePage(String navegador, IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String Delete(String check)
        {
            if (webDriver.FindElement(Elements.check).Text.Equals("INA") && check.Equals("True"))
            {
                webDriver.FindElement(Elements.btnEditar).Click();
                Thread.Sleep(1000);
                if (!webDriver.FindElement(Elements.cbEstado).Selected)
                {
                    webDriver.FindElement(Elements.cbEstado).Click();
                    Thread.Sleep(1000);
                    webDriver.FindElement(Elements.btnSubmit).Click();
                    Thread.Sleep(1000);
                    webDriver.FindElement(Elements.btnEliminar).Click();
                    Thread.Sleep(1000);
                }

                else
                {
                    webDriver.FindElement(Elements.btnSubmit).Click();
                    Thread.Sleep(1000);
                    webDriver.FindElement(Elements.btnEliminar).Click();
                    Thread.Sleep(1000);
                }
            }
            else
            {
                webDriver.FindElement(Elements.btnEliminar).Click();
            }

            Thread.Sleep(1000);

            return webDriver.FindElement(Elements.divMsjAlertaMain).Text;
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