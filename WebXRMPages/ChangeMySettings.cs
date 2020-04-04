using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Framework.Extensions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using WebXRM.WebXRMPages;

namespace WebXRMPages
{
    public class ChangeMySettings:BasePage
    {
        private IWebElement ddlDefaultCustomerSlideout => Driver.GetWebElementByXPath("//select[@name='CustomerView']");
        public ChangeMySettings(IWebDriver driver):base(driver)
        {

        }

        public void ChangetoEditView()
        {
            GoToChangeMySettingsPage();             
            Driver.SwitchToFrameById("_framepage");
            SelectElement customerView = new SelectElement(ddlDefaultCustomerSlideout);
            customerView.SelectByText("Edit View");
            Driver.GetWebElementByXPath("//input[@alt='Save']").Click();
            Driver.SwitchTo().DefaultContent();
        }

    }
}
