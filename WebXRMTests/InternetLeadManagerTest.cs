using Framework;
using Framework.Attributes;
using Framework.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebXRM.WebXRMPages;
using WebXRMPages;

namespace WebXRMTests
{
    [TestFixture]
    class InternetLeadManagerTest : TestBasePage
    {
        
        private ILM IlmPage;

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
            IlmPage = new ILM(driver);
        }

        [Test,Team("xrm core"),LoopProject(Project.XRMCore)]
        public void C003_Validate_ILM_FollowupOnly()
        {        
            IlmPage.GoToILMFollowUpOnly();
            Assert.IsTrue(IlmPage.Validate_FollowupOnlys());
            TestContext.WriteLine("ILM Followup test case done ");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All ILM test cases done ");
            driver.Quit();
        }
    }
}
