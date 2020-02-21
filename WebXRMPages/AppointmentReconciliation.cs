using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Framework.Extensions;
using System.Linq;


namespace WebXRM.WebXRMPages
{
   public class AppointmentReconciliation :BasePage
    { 
        
        private IWebElement comboSalesperson => Driver.GetWebElementByXPath("//a[contains(@id,'rcmbEmployee')]");
        private IWebElement btnSearch => Driver.GetWebElementByXPath("//a[@title='Preview All Customer']");
        public IWebDriver Driver;
        public AppointmentReconciliation(IWebDriver driver):base(driver)
        {
            Driver = driver; 
        }

        public int GetNumOfAppntsForSP(string salesperson)
        {
            GotoAppntReconPage();
            comboSalesperson.ClickAndWait();
            Driver.GetWebElementByXPath($"//li[@class='col1'][contains(text(),' {salesperson}')]").ClickAndWait();
            btnSearch.ClickAndWait();           
            return(Driver.GetWebElementsByXPath("//tr[contains(@id,'ApptReconciliationList')]/td[9]").Select(e => e.Text.Equals($"{salesperson}")).Count());
        }       

    }
}
