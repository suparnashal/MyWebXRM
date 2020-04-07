using MobileAutomation.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MobileAutomation.Screens
{
    public class LoginScreen : BaseAppScreen
    {
        private IWebElement TextFieldUsername => Driver.FindElement(By.Id("com.mobileupvn.mobilexrm:id/edtUser"));
        private IWebElement TextFieldPassword => Driver.FindElement(By.Id("com.mobileupvn.mobilexrm:id/edtPassword"));
        private IWebElement TextFieldDealerId => Driver.FindElement(By.Id("com.mobileupvn.mobilexrm:id/edtId"));
        private IWebElement ButtonLogin => Driver.FindElement(By.Id("com.mobileupvn.mobilexrm:id/btnLogin"));
       

        public LoginScreen(IWebDriver driver) : base(driver)
        {
            //
        }

        /// <summary>
        /// Login by using given user id and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="dealerId"></param>
        public void EnterLoginCredentials(string username, string password, string dealerId)
        {
            TextFieldUsername.SendKeys(username);
            TextFieldPassword.SendKeys(password);
            TextFieldDealerId.SendKeys(dealerId);
        }

        /// <summary>
        /// Clicks login button and takes user to homepage
        /// </summary>
        /// <returns></returns>
        public HomePage InitiateLogin()
        {
            ButtonLogin.Click();
            Thread.Sleep(6000);
            //Driver.WaitDisplayed(MenuLocator, 120);
            return new HomePage(Driver);
        }


    }
}
