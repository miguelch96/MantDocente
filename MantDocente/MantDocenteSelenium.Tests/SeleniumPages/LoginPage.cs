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
    class LoginPage
    {
        private string urlInicial;
        private IWebDriver webDriver;


        public LoginPage(String navegador, String urlInicial, bool remoto)
        {
            webDriver = DocenteDriver.InicializarDriver(navegador, remoto);
            this.urlInicial = urlInicial;
        }

        public void Login(String usuario, String passwd)
        {
            webDriver.Navigate().GoToUrl(urlInicial);
            webDriver.Manage().Window.Maximize();


            webDriver.FindElement(Elements.txtUsuario).SendKeys(usuario);
            webDriver.FindElement(Elements.txtPassword).SendKeys(passwd);
            webDriver.FindElement(Elements.btnIngresar).Click();

           
            Thread.Sleep(1500);
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