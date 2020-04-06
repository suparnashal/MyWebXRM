using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MobileAutomation.Framework;
using OpenQA.Selenium;
using MobileAutomation.Screens;

namespace MobileAutomation.Tests
{
    [TestFixture]
    public class LoginTests 
    {
        [Test]
        public void XrmAdminLogin()
        {
           IWebDriver  Driver = new XRMAndroidDriver();
            var loginScreen = new LoginScreen(Driver);

            loginScreen.EnterLoginCredentials("admin", "WIN445852crm!", "7132753501");
            HomePage homePage = loginScreen.InitiateLogin();
            Assert.True(homePage.AreMenuIconsDisplayed(), "Login not successful!");
        }
    }
}
