using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Framework
{
    public abstract class BrowserFactory
    {
        public static IWebDriver GetBrowser()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));
            driver.Manage().Window.Maximize(); 
            return driver;
        }
    }
}
