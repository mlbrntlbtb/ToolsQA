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
    public class SeleniumFindElement
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
            AutoDriver.Url = "https://demoqa.com";

            //Find element by Name
            IWebElement nameElement = AutoDriver.FindElement(By.Name("viewport"));

            //Find element by ClassName
            IWebElement classNameElement = AutoDriver.FindElement(By.ClassName("category-cards"));

            AutoDriver.Navigate().GoToUrl("https://demoqa.com/text-box");

            //Find element by XPath
            IWebElement xPathElement = AutoDriver.FindElement(By.XPath("//input[@id='userName']"));

            //Find element by ID
            IWebElement idElement = AutoDriver.FindElement(By.Id("userName"));

            //Find element by CSS Selector
            IWebElement cssSelectorElement = AutoDriver.FindElement(By.CssSelector("input[id=userName]"));
            cssSelectorElement = AutoDriver.FindElement(By.CssSelector("input#userName"));

            AutoDriver.Navigate().GoToUrl("https://demoqa.com/buttons");

            //Find element by TagName
            IWebElement tagNameElement = AutoDriver.FindElement(By.TagName("button"));

            AutoDriver.Navigate().GoToUrl("https://demoqa.com/links");

            //Find element by LinkText
            IWebElement linkTextElement = AutoDriver.FindElement(By.LinkText("Home"));

            //Find element by PartialLinkText
            IWebElement partalLinkTextElement = AutoDriver.FindElement(By.PartialLinkText("Content"));
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
