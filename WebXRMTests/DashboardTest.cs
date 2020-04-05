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
    class DashboardTest:TestBasePage
    {   
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
        }

        [Test,Team("xrm core"),LoopProject(Project.XRMCore)]
        public void C002_VerifyCreateDashboard()
        {
            /* These are basic steps to create a Dashboard
             * ARRANGE - decide dashbaord name
             * ACT:
             * login as admin
             * go to dashboard
             * click on +
             * click on next
             * Enter name of dashboard
             * click ok
             * close and click refresh
             * ASSERT :-
             * go to DB dropdown list and see if the dashboard is present there
             * then go and delete the dashboard
             */            
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
