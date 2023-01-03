using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumFluentWait
    {
        IWebDriver AutoDriver;
        //WebDriverWait wait;
        DefaultWait<IWebDriver> fluentWait;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
            fluentWait = new DefaultWait<IWebDriver>(AutoDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found.";
        }

        [Test]
        public void Test()
        {
            //Navigate to url
            AutoDriver.Url = "https://demoqa.com/";

            //Locators for target category elements
            string categoryMenu_XPath = "//div[@class='category-cards']";
            string categoryItems_XPath = "//div[contains(@class,'top-card')]";

            //Explicit wait for category elements
            IWebElement categoryMenu = fluentWait.Until(x => x.FindElement(By.XPath(categoryMenu_XPath)));
            List<IWebElement> categoryItems = fluentWait.Until(x=>x.FindElements(By.XPath(categoryItems_XPath))).ToList();

            //Get category item value then click
            string firstItemValue = categoryItems.FirstOrDefault().Text.Trim();
            categoryItems.FirstOrDefault().Click(); // Click first item on category menu
            Console.WriteLine("Category item: [" + firstItemValue + "] has been clicked.");

            //Locators for target accordion elements
            string accordionMenu_XPath = "//div[@class='accordion']";
            string accordionItems_XPath = "//div[@class='element-group']";

            //Explicit wait for accordion elements
            IWebElement accordion = fluentWait.Until(x=>x.FindElement(By.XPath(accordionMenu_XPath)));
            List<IWebElement> accordionItems = fluentWait.Until(x=>x.FindElements(By.XPath(accordionItems_XPath))).ToList();

            //Get accordion item value then click
            firstItemValue = accordionItems.FirstOrDefault().Text.Trim();
            accordionItems.FirstOrDefault().Click(); //Click first item on accordion
            Console.WriteLine("Accordion item: [" + firstItemValue + "] has been clicked.");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
