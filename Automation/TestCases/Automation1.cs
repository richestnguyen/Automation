using Automation.PageObjects;
using NUnit.Framework;

namespace Automation.TestCases
{
    public class Automation1 : TestBase
    {
        [Test]
        public void SearchText()
        {
            LogStep("Step 1", "Go to Swappa.com");
            var home = new HomePage(driver);

            LogStep("Step 2", "Search for \"Selenium\"");
            home.DoSearch("iPhone xs unlocked");
            var resultPage = new ResultPage(driver);
            resultPage.ClickOnResultLinkContainName(resultPage.GetAllResult());
        }
    }
}
