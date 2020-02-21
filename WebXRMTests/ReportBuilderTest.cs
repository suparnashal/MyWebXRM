using OpenQA.Selenium;
using NUnit.Framework;
using Framework;
using Framework.Extensions;
using System.Collections.Generic;
using System.Linq;
using Framework.Attributes;
using System.Reflection;
using System;
using Framework.Enums;
using WebXRMPages;
using WebXRM.WebXRMPages;


namespace WebXRMTests
{
    [TestFixture]
    class ReportBuilderTest
    {
        private IWebDriver driver; 

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }

        [Test]
        [Team("xrm integratopm")]
        [LoopProject(Project.XRMCore)]
        public void ValidateExporttoExcel()
        {
            //click on report builder menu item            
            Assert.IsTrue(new ReportBuilder(driver).ValidateReportDownload());           
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
