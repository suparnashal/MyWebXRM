using MobileAutomation.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAutomation.Screens
{
   public class HomePage: BaseAppScreen
    {
        private IWebElement ButtonMyOpenTask => Driver.FindElement(By.XPath("//*[@text ='My Open Tasks']"));
        
        public HomePage(IWebDriver driver):base(driver) 
        {
            
        }

        /// <summary>
        /// Check if all menu icons are displayed
        /// </summary>
        /// <returns></returns>
        public bool AreMenuIconsDisplayed()
        {
            return ButtonMyOpenTask.Displayed;
        }

    }
}
