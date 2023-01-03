using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumExplicitWaits
    {
        IWebDriver AutoDriver;
        WebDriverWait wait;
        IJavaScriptExecutor JavaScriptExecutor;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
            JavaScriptExecutor = (IJavaScriptExecutor)AutoDriver;
            wait = new WebDriverWait(AutoDriver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "Element to be searched not found.";
            wait.Until(w => JavaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete"));
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
            IWebElement categoryMenu = wait.Until(ExpectedConditions.ElementExists(By.XPath(categoryMenu_XPath)));
            List<IWebElement> categoryItems = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(categoryItems_XPath))).ToList();
            
            //Get category item value then click
            string firstItemValue = categoryItems.FirstOrDefault().Text.Trim();
            categoryItems.FirstOrDefault().Click(); // Click first item on category menu
            Console.WriteLine("Category item: [" + firstItemValue + "] has been clicked.");

            //Locators for target accordion elements
            string accordionMenu_XPath = "//div[@class='accordion']";
            string accordionItems_XPath = "//div[@class='element-group']";

            //Explicit wait for accordion elements
            IWebElement accordion = wait.Until(ExpectedConditions.ElementExists(By.XPath(accordionMenu_XPath)));
            List<IWebElement> accordionItems = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(accordionItems_XPath))).ToList();

            //Get accordion item value then click
            firstItemValue = accordionItems.FirstOrDefault().Text.Trim();
            accordionItems.FirstOrDefault().Click(); //Click first item on accordion
            Console.WriteLine("Accordion item: [" + firstItemValue + "] has been clicked.");

            wait.Until(w => (Boolean)JavaScriptExecutor.ExecuteScript("return window.jQuery != undefined && jQuery.active==0"));
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
