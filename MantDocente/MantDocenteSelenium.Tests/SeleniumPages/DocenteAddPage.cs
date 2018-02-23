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
    class DocenteAddPage
    {
        private IWebDriver webDriver;

        public DocenteAddPage(String navegador, bool remoto)
        {
            webDriver = DocenteDriver.InicializarDriver(navegador, remoto);
        }

        public DocenteAddPage(String navegador, IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String Add(String nombre, String apellido, String fechaNacimiento, String tipoDoc,String nroDoc)
        {
            webDriver.FindElement(Elements.btnAgregar).Click();
            Thread.Sleep(600);
            webDriver.FindElement(Elements.txtNombre).SendKeys(nombre);
            Thread.Sleep(600);
            webDriver.FindElement(Elements.txtApellido).SendKeys(apellido);
            Thread.Sleep(600);
            webDriver.FindElement(Elements.dtpFechaNacimiento).Clear();
            webDriver.FindElement(Elements.dtpFechaNacimiento).SendKeys(fechaNacimiento);
            Thread.Sleep(600);


            SelectElement cbbtipoDoc = new SelectElement(webDriver.FindElement(Elements.cbbTipoDocumento));
            cbbtipoDoc.SelectByValue(tipoDoc);
            Thread.Sleep(600);


            webDriver.FindElement(Elements.txtNroDocumento).SendKeys(nroDoc);
            Thread.Sleep(600);

            webDriver.FindElement(Elements.rbFemenino).Click();
            Thread.Sleep(600);

            webDriver.FindElement(Elements.btnSubmit).Click();
            Thread.Sleep(600);

            if (nombre.Equals("") || apellido.Equals("")|| fechaNacimiento.Equals("") || nroDoc.Equals("") || tipoDoc.Equals(""))
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