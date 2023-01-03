using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumHeadlessBrowser
    {
        IWebDriver AutoDriver;

        [SetUp]
        public void Initialize()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            chromeOptions.AddArgument("headless");
            firefoxOptions.AddArgument("--headless");

            //AutoDriver = new ChromeDriver(chromeOptions);
            AutoDriver = new FirefoxDriver(firefoxOptions);
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");
            Console.WriteLine("Page title: [" + AutoDriver.Title + "]");

            IWebElement categoryCards = AutoDriver.FindElement(By.XPath("//div[@class='category-cards']"));
            Console.WriteLine("Category cards: [" + categoryCards.Text + "]");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
