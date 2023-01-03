using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumMultipleBrowsers
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            //Handling multiple windows

            //Get parent window
            string parentWindowValue = AutoDriver.CurrentWindowHandle;
            Console.WriteLine("Parent window: [" + parentWindowValue + "] title: [" + AutoDriver.Title + "]");

            //Open new windows
            IWebElement newWindowButton = AutoDriver.FindElement(By.Id("windowButton")); //Also works with tabs
            for(int o=0; o<3; o++)
            {
                newWindowButton.Click();
                Thread.Sleep(1000);
            }

            //Get all windows and switch then close
            List<string> allWindows = AutoDriver.WindowHandles.ToList();
            foreach(var window in allWindows)
            {
                if(window != parentWindowValue)
                {
                    AutoDriver.SwitchTo().Window(window);
                    Console.WriteLine("Current window: [" + window + "] title: [" + AutoDriver.Title + "]");
                    AutoDriver.Close(); //Close current window
                }
            }

            //Switch back to parent window
            AutoDriver.SwitchTo().Window(parentWindowValue);
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close(); 
        }
    }
}
