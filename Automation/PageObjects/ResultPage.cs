using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Automation.PageObjects
{
    public class ResultPage : ScreenBase
    {

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);            
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"rso\"]/div/div/div[1]/div/div/h3/a")]
        private IWebElement FirstResult;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"rso\"]/div/div/div[2]/div/div/h3/a")]
        private IWebElement SecondResult;

        [FindsBy(How = How.PartialLinkText, Using = "Apple iPhone Xs (Unlocked)")]
        private IWebElement ResultItems;
        
        public List<IWebElement> GetAllResult()
        {
            var resultText = driver.FindElement(By.XPath("//*[@id=\"section_top\"]/div/div[2]/h2")).Text;
            var numberOfResult = resultText.Substring(0, resultText.IndexOf(" ", StringComparison.Ordinal));
            var listElemnt = new List<IWebElement>();
            WebDriverWait wait = new WebDriverWait(driver,new TimeSpan(30));
            for (int i = 1; i <= int.Parse(numberOfResult); i++)
            {
                listElemnt.Add(wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"#wrap > div > section.section_main > div > div:nth-child({i}) > div > a.title"))));
            }

            return listElemnt;
        }

        public void ClickOnResultLinkContainName(List<IWebElement> listElements, string itemName = null)
        {
            foreach (var element in listElements)
            {
                if (element.Text.StartsWith("Apple iPhone Xs") && !element.Text.Contains("Max") && element.Text.Contains("Unlocked"))
                {
                    element.Click();
                    return;
                }
            }
        }
    }
}
