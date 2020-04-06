using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAutomation.Framework
{
    public abstract class BaseAppScreen
    {
        public IWebDriver Driver;       

        /// <summary>
        /// Use only for Android-specific tasks in an Android app
        /// </summary>
        public AndroidDriver<IWebElement> AndroidDriver;  

        protected BaseAppScreen(IWebDriver driver)
        {
            Driver = driver;          
        }
    }
}
