using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumScreenshot
    {
        IWebDriver AutoDriver;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");
            Screenshot screenshot = ((ITakesScreenshot)AutoDriver).GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\Melbourne\Downloads\SeleniumScreenshot.Png", ScreenshotImageFormat.Png);
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
