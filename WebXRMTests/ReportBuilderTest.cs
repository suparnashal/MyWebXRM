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
    class ReportBuilderTest : TestBasePage
    {
        [OneTimeSetUp]
        public void OneTime()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
        }

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test,Team("xrm integratopm"),LoopProject(Project.XRMCore)]
        public void C004_ValidateExporttoExcel()
        {                    
            Assert.IsTrue(new ReportBuilder(driver).ValidateReportDownload());           
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
