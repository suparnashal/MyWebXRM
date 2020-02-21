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
            //IReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.XPath("//tr[contains(@id,'ApptReconciliationList')]/td[9]"));
            //return(elements.Select(e => e.Text.Equals($"{salesperson}")).ToList().Count); 
            //shortened form of above 2 stmts
            return(Driver.GetWebElementsByXPath("//tr[contains(@id,'ApptReconciliationList')]/td[9]").Select(e => e.Text.Equals($"{salesperson}")).Count());
        }

        //saved version of the GetNumOfAppntsForSP method. This one has comments.
        public int GetNumOfAppntsForSP_2()
        {
            //click on customers menu
            //Driver.ClickAndWait("//span[contains(text(),'Customers')][1]/..");
            //mnuCustomers.ClickAndWait();
            //click on appnts menu
            //mnuAppntReconciliation.ClickAndWait();
            Driver.SwitchToFrameById("_framepage");
            Driver.WaitUntilElementIsDisplayed("//a[.='Customer']");

            //select SP
            //Driver.ClickAndWait(); //ONLY PART OF THE ID value is used for comparison                        
            comboSalesperson.ClickAndWait();
            //Driver.ClickAndWait("//li[@class='col1'][contains(text(),' Adrain Villegas')]");
            Driver.GetWebElementByXPath("//li[@class='col1'][contains(text(),' Adrain Villegas')]").ClickAndWait();
            //click on search
            btnSearch.ClickAndWait();

            //find all the appnts
            IReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.XPath("//tr[contains(@id,'ApptReconciliationList')]/td[9]"));
            //elements.Select(e => e.Text.Trim()).ToList();  // this line might give some some error in immediate window, evaluation not supported in this context something of that nature
            //List<string> listOfAppnts = driver.GetTextOfAllElements("//tr[contains(@id,'ApptReconciliationList')]/td[9]");
            //count all the appnts that hv Adrain in SetFor field
            int count = elements.Select(e => e.Text.Equals("Adrain Villegas")).ToList().Count;
            return count;
        }

    }
}
