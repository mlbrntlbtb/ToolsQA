using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumBrowserNavigation
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/"); //More preferred than driver.Url;
            AutoDriver.Navigate().Back();
            AutoDriver.Navigate().Forward();
            AutoDriver.Navigate().Refresh();
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
