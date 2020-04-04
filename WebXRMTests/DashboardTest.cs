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
       
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }

        [Test]
        [Team("xrm core")]
        [LoopProject(Project.XRMCore)]
        public void C002_VerifyCreateDashboard()
        {
            /* These are basic steps to create a Dashboard
             * login as admin
             * go to dashboard
             * click on +
             * click on next
             * Enter name of dashboard
             * click ok
             * close and click refresh
             * go to DB dropdown list and see if the dashboard is present there
             * then go and delete the dashboard
             */
            int[] listofintegers = new int[] {2,4,5,8,10,13,15 };
         int sum= listofintegers.Where(i => i % 2 == 0).Sum(i => i);
            sum = sum + 0;
            
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
