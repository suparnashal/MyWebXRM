using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAutomation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //AndroidDriver<AppiumWebElement> driver = new AndroidDriver();
        }

        [Test]
        public void Test1()
        {
            
            Assert.Pass();
        }
    }
}