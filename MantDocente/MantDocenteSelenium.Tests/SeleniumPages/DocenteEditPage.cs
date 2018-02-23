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
    class DocenteEditPage
    {
 
        private IWebDriver webDriver;


        public DocenteEditPage(String navegador, bool remoto)
        {
            webDriver = DocenteDriver.InicializarDriver(navegador, remoto);
        }

        public DocenteEditPage(String navegador, IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String Edit(String nombre, String apellido,String tipoDoc)
        {
            //PANTALLA MAIN
            Thread.Sleep(1000);
            webDriver.FindElement(Elements.btnEditar).Click();
            Thread.Sleep(1000);

            //PANTALLA EDITAR DOCENTE
            webDriver.FindElement(Elements.txtNombre).Clear();
            Thread.Sleep(1000);
            webDriver.FindElement(Elements.txtNombre).SendKeys(nombre);
            Thread.Sleep(1000);
            webDriver.FindElement(Elements.txtApellido).Clear();
            Thread.Sleep(1000);
            webDriver.FindElement(Elements.txtApellido).SendKeys(apellido);
            Thread.Sleep(1000);

            SelectElement cbbTipoDoc = new SelectElement(webDriver.FindElement(Elements.cbbTipoDocumento));
            cbbTipoDoc.SelectByValue(tipoDoc);
            Thread.Sleep(1000);

            webDriver.FindElement(Elements.btnSubmit).Click();
            Thread.Sleep(1000);

            if (nombre.Equals("") || apellido.Equals("") ||  tipoDoc.Equals(""))
            {
                return webDriver.FindElement(Elements.divMsjAlertaAddEdit).Text;
            }

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
