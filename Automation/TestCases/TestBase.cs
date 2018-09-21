using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Automation.PageObjects
{
    public class TestBase
    {
        protected IWebDriver driver;
        public string Url = "https://swappa.com/";
        [SetUp]
        public void SetUp()
        {
            TestContext.Progress.WriteLine("Driver Started");
            driver = new ChromeDriver();
            driver.Url = Url;
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Failed image:");
            Capture();
            TestContext.Progress.WriteLine("Driver Quit");
            driver.Quit();
        }

        public void Capture()
        {

        }

    }
}
