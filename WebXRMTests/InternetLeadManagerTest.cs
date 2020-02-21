﻿using Framework;
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
    class InternetLeadManagerTest
    {
        private IWebDriver driver;
        private ILM IlmPage;
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            new LoginPage(driver).OpenUrlAndLogin();
            IlmPage = new ILM(driver);
        }

        [Test]        
        [Team("xrm core")]
        [LoopProject(Project.XRMCore)]
        public void Validate_ILM_FollowupOnly()
        {
            /*Go to ILM page
             * Click on Followup only
             * change date range to today's date to today's date
             * check if all customers hv that date in them
             * if yes then works ok else error
             * */
            IlmPage.GoToILMFollowUpOnly();

           Assert.IsTrue(IlmPage.Validate_FollowupOnlys());
           TestContext.WriteLine("ILM Followup test case done ");
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("All ILM test cases done ");
            driver.Quit();
        }
    }
}