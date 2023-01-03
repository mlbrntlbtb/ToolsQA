using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumActionsClass
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/text-box");

            IWebElement targetTextBox = AutoDriver.FindElement(By.Id("userName"));

            //Set upper case value using SHIFT key
            Actions actions = new Actions(AutoDriver);
            actions.KeyDown(targetTextBox, Keys.Shift).SendKeys("john wick").KeyUp(targetTextBox, Keys.Shift);
            //actions.KeyDown(targetTextBox, Keys.Shift).SendKeys("john wick").KeyUp(targetTextBox, Keys.Shift).Build().Perform();
            IAction action = actions.Build();
            action.Perform();

            IWebElement targetElement = AutoDriver.FindElement(By.Id("someElement"));
            IWebElement fromElement = AutoDriver.FindElement(By.Id("fromElement"));
            IWebElement toElement = AutoDriver.FindElement(By.Id("toElement"));

            //Keyboard events
            actions.KeyDown(targetTextBox, Keys.Shift);
            actions.SendKeys("john wick");
            actions.KeyUp(targetTextBox, Keys.Shift);

            //Mouse events
            actions.Click();
            actions.DoubleClick();
            actions.ContextClick();
            actions.ClickAndHold();
            actions.DragAndDrop(fromElement, toElement);
            actions.DragAndDropToOffset(fromElement, 0, 0);
            actions.MoveToElement(targetElement);
            actions.MoveByOffset(0, 0);
            actions.Release();
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
