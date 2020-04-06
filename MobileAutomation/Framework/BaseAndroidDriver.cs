using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace MobileAutomation.Framework
{
    public abstract class BaseAndroidDriver : AndroidDriver<IWebElement>
    {        
        protected BaseAndroidDriver(Uri AppiumAddress): base(AppiumAddress, CreateOptionsForApp(), TimeSpan.FromMinutes(10))
        {            
            
        }

        private static AppiumOptions CreateOptionsForApp()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("deviceName", "Pixel 3a API 28");
            return options;
            
        }

    }
}