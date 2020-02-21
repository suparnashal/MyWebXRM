using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Framework.Extensions;
using System.Xml.Linq;
using System.Xml.XPath;
using WebXRMPages;

namespace WebXRM.WebXRMPages
{
    public class LoginPage
    {
        private IWebElement txtPassword => Driver.GetWebElementByXPath("//input[@name='txtPassword']");
        private IWebElement txtDealerID => Driver.GetWebElementByXPath("//input[@name='txtDealerID']");
        private  IWebElement txtUsername => Driver.GetWebElementByXPath("//input[@name='txtUserName']");
        private IWebElement btnLogin => Driver.GetWebElementByXPath("//a[@id='btnLogin']");

        public static IWebDriver Driver;
          public LoginPage(IWebDriver driver) //Driver is always set in the constructor
        {
            Driver = driver; 
        }

        public void OpenUrlAndLogin()
        {
            Driver.Navigate().GoToUrl("https://www.car-research.com/WebXRM/");
            Config configinfo = new Config();  
            txtUsername.SendKeys(configinfo.username);            
            txtPassword.SendKeys(configinfo.password);            
            txtDealerID.SendKeys(configinfo.dealerid);            
            btnLogin.Click();
        }


    }
}
