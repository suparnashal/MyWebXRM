using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebXRM.WebXRMPages;
using Framework;
using Framework.Extensions;


namespace WebXRMPages
{
    public class ShowroomControlManager:BasePage
    {

        private IWebElement btnTopSearch => Driver.GetWebElementByXPath("//a[.='Search']");        
        public ShowroomControlManager(IWebDriver driver):base(driver)
        {            
        }        

        public void SearchForCustomerByID(string customerid)
        {
            //click on search button
            btnTopSearch.ClickAndWait();
            Driver.SwitchToFrameById("_framepage");
            Driver.GetWebElementByXPath("//input[contains(@id,'rtbCustID')]").SendKeys(customerid);
            Driver.GetWebElementByXPath("//a[.=' Search']").ClickAndWait();
            Driver.GetWebElementByXPath("//a[@title='View Customer']").ClickAndWait();
        }

        public void NewShowroomVisit()
        {
            Driver.GetWebElementByXPath("//a[.='New Event']").ClickAndWait();
            Driver.GetWebElementByXPath("//a[.='Showroom Visit']").ClickAndWait();
            Driver.SwitchToNewTab();
            Driver.GetWebElementByXPath("//a[.=' Save']").ClickAndWait();
            Driver.SwitchToFirstTab();
        }

        public void RefreshCustomerEditView()
        {
            Driver.SwitchToFrameById("_framepage");
            Driver.GetWebElementByXPath("//a[.=' Refresh']").ClickAndWait();
        }
        public void AddShowroomEvent()
        {
            SearchForCustomerByID("2712272");
            NewShowroomVisit();
            RefreshCustomerEditView();
            FilterShowroomEvent();
            //get all span elements with contact date and check if they hv given date
            int numOfShVisitsToday = Driver.GetWebElementsByXPath("//span[@title='Contact Date'][contains(text(),'12/11/2019')]").Count;             
        }

        private void FilterShowroomEvent()
        {
            Driver.GetWebElementByXPath("//a[.='Show Filters']").ClickAndWait();
            Driver.GetWebElementByXPath("//a[contains(@id,'rcmbEventTypeFilter')][.='select']").ClickAndWait();
            Driver.GetWebElementByXPath("//label[.='Showroom']").ClickAndWait(4000);
        }

        public string AddPhoneEvent()
        {
            SearchForCustomerByID("2709269");
            Driver.GetWebElementByXPath("//a[.='New Event']").ClickAndWait();
            Driver.GetWebElementByXPath("//a[.='Phone Call']").ClickAndWait();
            Driver.SwitchToNewTab();
            Driver.GetWebElementByXPath("//i[contains(@title,'Choose Vehicle')]").ClickAndWait();
            Driver.SwitchTo().Frame("RadWindowChooseVehicle");
            // look into wait
            Driver.GetWebElementByXPath("//span[.=' Search']").ClickAndWait();

            ////input[contains(@id,"_rtbStockNum")][2]

            Driver.GetWebElementByXPath("//tr[contains(@id,'rgvVehicles_ctl00__0')]/td[5]").MouseDoubleClick(); //.. this is correct one
            Driver.SwitchTo().DefaultContent();
            String attributes = Driver.GetWebElementByXPath("//input[contains(@id,'_rtbStockNum')][2]").GetAttribute("value");
            String stock = System.Text.RegularExpressions.Regex.Split(attributes, "{\"|\":|,\"|\"")[17];
            return stock;
            //String[] strings = System.Text.RegularExpressions.Regex.Split("\"",attributes) ;

        }
    }
}
