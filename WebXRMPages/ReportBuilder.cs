using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebXRM.WebXRMPages;
using Framework;
using Framework.Extensions;
using Framework.Helpers;


namespace WebXRMPages
{
    public class ReportBuilder: BasePage
    {
        private IWebElement lnkCustom => Driver.GetWebElementByXPath("//span[.='CUSTOM']");
        private IWebElement lnSSTestReports => Driver.GetWebElementByXPath("//span[.='Suparna Test Reports']/preceding-sibling::span[1]");
        private IWebElement scrollbar => Driver.GetWebElementByXPath("//div[contains(@id,'AdHocReport')]");
        private IWebElement btnTestReport => Driver.GetWebElementByXPath("//span[.='Showroom visits']");
        private IWebElement btnRunReport => Driver.GetWebElementByXPath("//span[.=' Run Report']");

        private IWebElement btnExportToExcel => Driver.GetWebElementByXPath("//a[.='Export to Excel']");

        public ReportBuilder(IWebDriver _driver):base(_driver)
        {
            
        }

        public bool ValidateReportDownload()
        {
            GoToReportBuilder();
            Driver.SwitchToFrameById("_framepage");
            lnkCustom.ClickAndWait();          
            lnSSTestReports.ClickAndWait();                    
            scrollbar.MoveScrollBar(500); 
            btnTestReport.ClickAndWait();                 
            btnRunReport.ClickAndWait();            
            GlobalHelpers gs = new GlobalHelpers();
            gs.DeleteFilesFromDirectory("RadGridExport*");
            Driver.SwitchTo().Frame("RadWindowRunReportFolder");
            btnExportToExcel.ClickAndWait();           
            return gs.DownloadFilePresent("RadGridExport*");
        }

    }
}
