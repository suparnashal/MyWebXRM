﻿using OpenQA.Selenium;
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
        public bool AddShowroomEvent()
        {
            SearchForCustomerByID("2712272");
            NewShowroomVisit();
            RefreshCustomerEditView();
            FilterShowroomEvent();          
            int numOfShVisitsToday = Driver.GetWebElementsByXPath("//span[@title='Contact Date'][contains(text(),'12/11/2019')]").Count;
            return ((numOfShVisitsToday > 0) ? true : false);                
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
            Driver.GetWebElementByXPath("//span[.=' Search']").ClickAndWait(); 
            Driver.GetWebElementByXPath("//tr[contains(@id,'rgvVehicles_ctl00__0')]/td[5]").MouseDoubleClick(); 
            Driver.SwitchTo().DefaultContent();
            String attributes = Driver.GetWebElementByXPath("//input[contains(@id,'_rtbStockNum')][2]").GetAttribute("value");
            String stock = System.Text.RegularExpressions.Regex.Split(attributes, "{\"|\":|,\"|\"")[17];
            return stock;     

        }
    }
}
