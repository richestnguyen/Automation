using Automation.PageObjects;
using NUnit.Framework;

namespace Automation.TestCases
{
    public class Automation1 : TestBase
    {
        [Test]
        public void SearchText()
        {
            LogStep("Step 1", "Go to Google");
            var home = new HomePage(driver);

            LogStep("Step 2", "Search for \"Selenium\"");
            home.DoSearch("Selenium");
            home.TitleBarShouldBe("Selenium");
            var resultPage = new ResultPage(driver);

            LogStep("Step 3", "Click on 2nd link");
            resultPage.ClickOnFirstResultLink(2);
        }
    }
}
