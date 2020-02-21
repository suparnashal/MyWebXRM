using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebXRM.WebXRMPages;
using Framework;
using Framework.Extensions;
using System.Linq;
using System.Collections.ObjectModel;
using Framework.Helpers;

namespace WebXRMPages
{
   public class ILM:BasePage
    {
        
        public ILM(IWebDriver driver):base(driver)
        {

        }

        public bool Validate_FollowupOnlys()
        {            
            Driver.SwitchToFrameById("_framepage");
            List<IWebElement> calenderpopup1 = Driver.GetWebElementsByXPath("//a[.='Open the calendar popup.']") ;
            IWebElement[] calenderpopup2 = calenderpopup1.ToArray();
            calenderpopup2[1].ClickAndWait();          
            Driver.GetWebElementByXPath($"//a[.='{DateTimePicker.currentDate}']").ClickAndWait();
            calenderpopup2[1].ClickAndWait();
            calenderpopup2[0].ClickAndWait();
            Driver.GetWebElementByXPath($"//a[.='{DateTimePicker.currentDate}']").ClickAndWait();           
            Driver.SwitchTo().DefaultContent();
            Driver.SwitchToFrameById("_framepage");
            ReadOnlyCollection<IWebElement> custNames = Driver.FindElements(By.XPath("//a[contains(@id,'lnkCustomer')]"));      
            List<String> NamesOnly = custNames.Select(t => t.Text).ToList();
            bool status = NamesOnly.All(s =>
            {
                int index = s.IndexOf("/16/20");
                if (index >= 0) return true;
                return false;
            }
            );
            return status;
        }
    }
}
