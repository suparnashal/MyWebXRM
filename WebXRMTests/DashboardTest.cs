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
    class DashboardTest
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
        public void VerifyCreateDashboard()
        {
            /* login as admin
             * go to dashboard
             * click on +
             * click on next
             * Enter name of dashboard
             * click ok
             * close and click refresh
             * go to DB dropdown list and see if the dashboard is present there
             * then go and delete the dashboard
             */
             
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
