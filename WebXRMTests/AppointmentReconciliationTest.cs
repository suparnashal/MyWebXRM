using OpenQA.Selenium;
using NUnit.Framework;
using Framework;
using Framework.Extensions;
using System.Collections.Generic;
using System.Linq;
using WebXRM.WebXRMPages;
using Framework.Attributes;
using System.Reflection;
using System;
using Framework.Enums;

namespace WebXRMTests
{
    [TestFixture]
    public class AppointmentReconciliationTest
    {
        private IWebDriver driver;   

        
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }        

        [Test]
        [Team("xrm core")]
        [LoopProject(Project.XRMCore)]
        public void AppointmentReconValidateFilterbySP()
        {

            //just tyring to get the Team attribute
            Type class_type = typeof(AppointmentReconciliationTest);
            MethodInfo minfo = class_type.GetMethod("AppointmentReconValidateFilterbySP");
            TeamAttribute team_attribute = (TeamAttribute)Attribute.GetCustomAttribute(minfo, typeof(TeamAttribute));
            string teamname = team_attribute.teamname;

            //set number of appnt for Adrain
            //i hv hardcoded this for now, in real test we will create this test data   
            Assert.AreEqual(1, new AppointmentReconciliation(driver).GetNumOfAppntsForSP("Adrain Villegas"));
            TestContext.WriteLine("Appnt recon validate filterby SP test case done ");

        }

        [Test]
        public void ValidateMarkShowedLinkForAppoin()
        {
            //we know what customer to use since we hv initialized it in Onetimesetup
            //AppointmentReconciliation AppRecon = new AppointmentReconciliation(driver);
            //AppRecon.AddPhoneEvent("2736201");
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All appnt recon test cases done");
            driver.Quit();
        }
    }
}
