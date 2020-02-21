using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Framework.Extensions
{
    public static class WebDriverExtensions
    {

        public static IWebElement GetWebElementByXPath(this IWebDriver driver, string locator)
        {
            //need System.Collections.ObjectModel included to access this class
            ReadOnlyCollection<IWebElement> elements = null;
            int pollinginterval = 350, timeout = 3000, elapsedtime=0;

            while (elapsedtime < timeout)
            {
                try
                {
                      elements = driver.FindElements(By.XPath(locator));
                    if (elements.Count > 0)
                    {
                        return elements.First();
                    }
                }
                catch (StaleElementReferenceException)
                {

                }                
                Thread.Sleep(pollinginterval);
                elapsedtime += pollinginterval;
            }
            return driver.FindElement(By.XPath(locator));

        }

        public static void WaitUntilElementIsDisplayed(this IWebDriver driver,string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30));
            wait.Until(d => d.FindElement(By.XPath(locator)).Displayed);
            
        }

        public static void SwitchToFrameById(this IWebDriver driver,string frameid)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id(frameid)));
        }
        
        public static List<IWebElement> GetWebElementsByXPath(this IWebDriver driver, string locator)
        {
            return driver.FindElements(By.XPath(locator)).ToList();
        }

        public static void SwitchToNewTab(this IWebDriver driver)
        {
            List<string> tabs = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(tabs.Last());
        }

        public static void SwitchToFirstTab(this IWebDriver driver)
        {
            List<string> tabs = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(tabs.First());
        }

       public static void Test(this IWebDriver driver)
        {
            //WebDriverWait w = new WebDriverWait()
        }

    }
}
