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

        [OneTimeSetUp ]
        public void OneTime()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }

        [SetUp]     
        public void Setup()
        {
          
        }

        [Test]
        [Team("xrm integratopm")]        
        [LoopProject(Project.XRMCore)]
        public void ValidateAddShowroomEvent()
        {
           
            new ChangeMySettings(driver).ChangetoEditView(); 
            new ShowroomControlManager(driver).AddShowroomEvent();           
            TestContext.WriteLine("Added Showroom event . Ran test case ");   

        }

        [Test]
        [Author("Suparna")]
        [Team("xrm integratopm")]
        [LoopProject(Project.XRMCore)]
        //we can write following method in another class where we code all phone events but writing test here for simplicity for my test project
        public void ValidateStockPopuluatedOnPhoneEvent()
        {           
            //Change settings to edit view
            new ChangeMySettings(driver).ChangetoEditView();
            //search for customer #2709269
            ShowroomControlManager s = new ShowroomControlManager(driver);           
            Assert.AreEqual(s.AddPhoneEvent(), "161348");        
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All showroom tests done");
            driver.Quit();
        }
    }
}
