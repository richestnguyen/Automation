using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
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
            TestContext.Progress.WriteLine("Tear down!");
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed) 
            {
                TestContext.Progress.WriteLine("Capture last screen:");
                CaptureLastScreen();
            }

            TestContext.Progress.WriteLine("Driver Quit");
            driver.Quit();
            driver = null;

        }

        public void CaptureLastScreen()
        {
            var failedTestDataFolder = $"{Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\FailedTestData\\"))}";
            if (!Directory.Exists(failedTestDataFolder))
            {
                Directory.CreateDirectory(failedTestDataFolder);
            }

            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage((Image) printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save($"{failedTestDataFolder}{TestContext.CurrentContext.Test.Name}{DateTime.UtcNow.ToString("yyyyMMdd HHmmss %K")}_LastScreen.jpg", ImageFormat.Jpeg);
        }

        public void LogStep(string stepName, string stepDescription)
        {
            TestContext.Progress.WriteLine($"{stepName}: {stepDescription}");
        }
    }
}
