using Automation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automation.PageObjects;

namespace Automation.TestCases
{
    public class Automation1 : TestBase
    {
        [Test]
        public void SearchText()
        {
            TestContext.Progress.WriteLine("Step 1: Go to Google");
            var home = new HomePage(driver);
            TestContext.Progress.WriteLine("Step 2: Search for \"Selenium\"");
            home.DoSearch("Selenium");
            home.TitleBarShouldBe("Selenium");
            var resultPage = new ResultPage(driver);
            TestContext.Progress.WriteLine("Step 3: Click on 2nd link");
            resultPage.ClickOnFirstResultLink(2);
        }
  
    }
}
