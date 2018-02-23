using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace MantDocente.Tests.SeleniumPages.Driver
{
    class DocenteDriver
    {
        private static String URL_NODE = "http://localhost:50963/";

        public static IWebDriver InicializarDriver(String navegador, bool remoto)
        {
            IWebDriver webDriver = null;
            try
            {
                switch (navegador)
                {
                    case "chrome":
                        if (remoto)
                        {
                            Uri server=new Uri(URL_NODE);
                            DesiredCapabilities capabilities=DesiredCapabilities.Chrome();
                            webDriver=new RemoteWebDriver(server,capabilities);
                        }
                        else
                        {
                            webDriver=new ChromeDriver();
                        }
                        break;
                    case "iexplorer":
                        if (remoto)
                        {
                            Uri server = new Uri(URL_NODE);
                            DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                            webDriver = new RemoteWebDriver(server, capabilities);
                        }
                        else
                        {
                            webDriver = new EdgeDriver();
                        }
                        break;
                    case "firefox":
                        if (remoto)
                        {
                            Uri server = new Uri(URL_NODE);
                            DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                            webDriver = new RemoteWebDriver(server, capabilities);
                        }
                        else
                        {
                            webDriver = new FirefoxDriver();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return webDriver;
        }

        public static void CerrarPagina(IWebDriver driver)
        {
            if (driver!=null)
            {
                driver.Quit();
            }
        }
    }
}
