using Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebXRM.WebXRMPages;
using WebXRMPages;
using Framework.Attributes;
using Framework.Enums;

namespace WebXRMTests
{
    [TestFixture]
    class ShowroomControlManagerTest
    {
        private IWebDriver driver;

        [OneTimeSetUp ] // one time setup needed for all the tests eg.create common objects for the tests, login page etc.
        public void OneTime()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }

        [SetUp] // run before every test so put the initialization needed for every test. like if some values need to be reset before 
         // every test
        public void Setup()
        {
          
        }

        [Test]
        [Team("xrm integratopm")]        
        [LoopProject(Project.XRMCore)]
        public void ValidateAddShowroomEvent()
        {
            //Change settings to edit view
            new ChangeMySettings(driver).ChangetoEditView(); 

            new ShowroomControlManager(driver).AddShowroomEvent();
            //LogMessage(TestContext.CurrentContext.WorkerId, "Added Showroom event");
            TestContext.WriteLine("Added Showroom event . Ran test case ");

            //TestContext.CurrentContext.Test.ID

            //search for a given custmer cust#2712272
            
            //add showroom event
            //go to SCM
            //check if you see that customer
            //click on customer
            //verify slideout opens


        }

        [Test]
        [Author("Suparna")]
        [Team("xrm integratopm")]
        [LoopProject(Project.XRMCore)]
        //we can write following method in another class where we code all phone events but writing test here for simplicity
        public void ValidateStockPopuluatedOnPhoneEvent()
        {           
            //Change settings to edit view
            new ChangeMySettings(driver).ChangetoEditView();
            //search for customer #2709269
            ShowroomControlManager s = new ShowroomControlManager(driver);           
            Assert.AreEqual(s.AddPhoneEvent(), "161348");
            //Add phone event new > Phone call
            //select stock#, click on stock button select a vehicle and make sure that vehicle fields populate
            //if all fields populate then tests pass
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All showroom tests done");
            driver.Quit();
        }
    }
}
