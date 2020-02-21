using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions;

namespace Framework.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickAndWait(this IWebElement element, int timeout = 1000)
        {            
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30));
            element.Click();
            Thread.Sleep(timeout);
        }

        public static void MoveScrollBar(this IWebElement element,int range)
        {
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;                      
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].scrollBy(0,{range})", element);
        }

        public static void MouseDoubleClick(this IWebElement element)
        {
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
            Actions action = new Actions(driver);
            action.MoveToElement(element).DoubleClick().Perform();
        }
    }
}
