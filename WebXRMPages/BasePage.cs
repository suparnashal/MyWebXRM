using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Framework.Extensions;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace WebXRM.WebXRMPages
{
    public class BasePage
    {
        private IWebElement mnuCustomers => Driver.GetWebElementByXPath("//span[contains(text(),'Customers')][1]/..");
        private IWebElement mnuAppntReconciliation => Driver.GetWebElementByXPath("//a[.='Appointment Reconciliation']");
        private IWebElement mnuShowroomControlManager => Driver.GetWebElementByXPath("//a/span[contains(text(),'Showroom Control Manager')]");
        private IWebElement mnuChangeMySettings => Driver.GetWebElementByXPath("//a[.='Change My Settings']");

       
        protected IWebDriver Driver; 
        public BasePage(IWebDriver driver)
        {
            Driver = driver;           

        }

        public void GoToReportBuilder()
        {
            IWebElement reports_menu = Driver.GetWebElementByXPath("//a/span[.='Reports']");
            reports_menu.ClickAndWait();
            IWebElement reports = Driver.GetWebElementByXPath("//a/span[.='Report Builder']");
            reports.ClickAndWait();

        }
        public void AddPhoneEvent(string customerid)
        {
            GotoSearchPage();
            Driver.SwitchToFrameById("_framepage");
            IWebElement searchbox = Driver.GetWebElementByXPath("//input[contains(@name,'CustID')]");
            searchbox.SendKeys(customerid);
            Driver.GetWebElementByXPath("//a[.=' Search']").ClickAndWait();
            Driver.GetWebElementByXPath($"//a[.='{customerid}']");
            Driver.GetWebElementByXPath($"//a[.='{customerid}']").ClickAndWait();            
        }

        public void GotoAppntReconPage()
        {
            mnuCustomers.ClickAndWait();
            mnuAppntReconciliation.ClickAndWait();
            Driver.SwitchToFrameById("_framepage");
            Driver.WaitUntilElementIsDisplayed("//a[.='Customer']");
        }

        public void GoToChangeMySettingsPage()
        {
            Driver.GetWebElementByXPath("//span[.='Maintenance']").ClickAndWait();
            mnuChangeMySettings.ClickAndWait();
           
        }

        public void GoToDashboard()
        {
            Driver.GetWebElementByXPath("//a[.='My Dashboard']").ClickAndWait(3000) ;

        }

        public void GoToILMFollowUpOnly()
        {
            Driver.GetWebElementByXPath("//a[.='XRM']").ClickAndWait();
            Driver.GetWebElementByXPath("//a[.='ILM']").ClickAndWait();
            Driver.SwitchToFrameById("_framepage");
            Driver.GetWebElementByXPath("//span[.='Follow-Up Only']").ClickAndWait();
            Driver.SwitchTo().DefaultContent();
        }

        public void GotoSearchPage()
        {
            Driver.GetWebElementByXPath("//a[.='Search']").ClickAndWait();

        }

        public void FindCustomer()
        {

        }

    }
}