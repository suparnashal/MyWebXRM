using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAutomation.Framework
{
    public class XRMAndroidDriver : BaseAndroidDriver
    {
        public static Uri AppiumAddress = new Uri("http://localhost:4723/wd/hub/");
        public XRMAndroidDriver():base(AppiumAddress)
        {
           
        }
    }
}
