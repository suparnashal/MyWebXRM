using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using WebXRM.WebXRMPages;
using Framework.Extensions;
using OpenQA.Selenium;
using Framework;

namespace WebXRMTests
{
   [SetUpFixture]
   public class Startup
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //Setup data here
            //create a list of test customers to use. this is our test data
            Dictionary<string, string> custValues = new Dictionary<string, string>()
            {
                {"2736201","Julie Barker" },{"2661515","Mary Anderson"}
            };

            //create a phone event with an appnt
            IWebDriver driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
            new BasePage(driver).AddPhoneEvent(custValues.Keys.First());
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }

   [TestFixture]
    public class TestBasePage
    {
        protected IWebDriver driver;
        [SetUp]
        public virtual void Setup()
        {           
        }
     
        [TearDown]
        public virtual void Teardown()
        {

        }
    }
}
