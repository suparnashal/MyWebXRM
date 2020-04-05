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
    public class AppointmentReconciliationTest : TestBasePage
    {
        private AppointmentReconciliation apptRecon;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }        

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            apptRecon = new AppointmentReconciliation(driver);
        }
       
        public void SavedTest_AppointmentReconValidateFilterbySP()
        {

            //just tyring to get the Team attribute
            //Type class_type = typeof(AppointmentReconciliationTest);
            //MethodInfo minfo = class_type.GetMethod("AppointmentReconValidateFilterbySP");
            //TeamAttribute team_attribute = (TeamAttribute)Attribute.GetCustomAttribute(minfo, typeof(TeamAttribute));
            //string teamname = team_attribute.teamname;

            //set number of appnt for Adrain
            //i hv hardcoded this for now, in real test we will create this test data   
            Assert.AreEqual(1, apptRecon.GetNumOfAppntsForSP("Adrain Villegas"));
            TestContext.WriteLine("Appnt recon validate filterby SP test case done ");

        }

        [Test,Team("xrm core"),LoopProject(Project.XRMCore)]
        public void C001_AppointmentReconValidateFilterbySP()
        {      
            //Adding comments for explanation. In prod code there will not be any comments.Codewill be readable.          
            //1.Arrange
            //set number of appnt for Adrain
            //i hv hardcoded this for now, in real test we will create this test data  

            //2.Act and 3.Assert are combined in following step
            Assert.AreEqual(1, apptRecon.GetNumOfAppntsForSP("Adrain Villegas"));
            TestContext.WriteLine("Appnt recon validate filterby SP test case done ");

        }
       
        [OneTimeTearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All appnt recon test cases done");
            driver.Quit();
        }
    }
}
