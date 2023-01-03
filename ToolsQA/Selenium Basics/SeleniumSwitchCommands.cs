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
    public class SeleniumSwitchCommands
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/alerts");

            // Test Switch to Alert

            //Open alert
            IWebElement alertButton = AutoDriver.FindElement(By.Id("alertButton"));
            alertButton.Click();

            //Switch to alert
            IAlert simpleAlert = AutoDriver.SwitchTo().Alert();

            //Get alert value
            string simpleAlertValue = simpleAlert.Text;
            Console.WriteLine("Simple Alert Value: [" + simpleAlertValue + "]");

            //Accept alert
            simpleAlert.Accept();



            //Test Switch to Frame

            AutoDriver.Navigate().GoToUrl("https://demoqa.com/frames");

            //Switch to frame
            string firstFrameName = "frame1";
            AutoDriver.SwitchTo().Frame(firstFrameName);

            //Get element from frame
            IWebElement elementFromFrame = AutoDriver.FindElement(By.Id("sampleHeading"));
            string elementFromFrameValue = elementFromFrame.Text;
            Console.WriteLine("Element from [" + firstFrameName + "]: [" + elementFromFrameValue + "]");

            //Switch to parent frame
            AutoDriver.SwitchTo().ParentFrame();

            //Switch to frame
            string secondFrameName = "frame2";
            AutoDriver.SwitchTo().Frame(secondFrameName);

            //Get element from frame
            IWebElement elementFromFrame2 = AutoDriver.FindElement(By.Id("sampleHeading"));
            string elementFromFrame2Value = elementFromFrame2.Text;
            Console.WriteLine("Element from [" + secondFrameName + "]: [" + elementFromFrame2Value + "]");

            //Switch to default content
            AutoDriver.SwitchTo().DefaultContent();

            //Get element from parent frame
            IWebElement accordion = AutoDriver.FindElement(By.ClassName("accordion"));
            string accordionValue = accordion.Text;
            Console.WriteLine("Element from parent frame: [" + accordionValue + "]");



            //Test Switch to Tab

            AutoDriver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            //Get parent window
            string parentWindowValue = AutoDriver.CurrentWindowHandle;
            Console.WriteLine("Parent window: [" + parentWindowValue + "] title: [" + AutoDriver.Title + "]");

            //Open new tab
            IWebElement newTabButton = AutoDriver.FindElement(By.Id("tabButton"));
            for (int o = 0; o < 3; o++)
            {
                newTabButton.Click();
                Thread.Sleep(1000);
            }

            //Get all tabs and switch then close
            List<string> allTabs = AutoDriver.WindowHandles.ToList();
            foreach (var tab in allTabs)
            {
                if (tab != parentWindowValue)
                {
                    AutoDriver.SwitchTo().Window(tab);
                    Console.WriteLine("Current tab: [" + tab + "] title: [" + AutoDriver.Title + "]");
                    AutoDriver.Close(); //Close current tab
                }
            }

            //Switch back to parent window
            AutoDriver.SwitchTo().Window(parentWindowValue);



            //Test Switch to Window

            //Open new windows
            IWebElement newWindowButton = AutoDriver.FindElement(By.Id("windowButton"));
            for (int o = 0; o < 3; o++)
            {
                newWindowButton.Click();
                Thread.Sleep(1000);
            }

            //Get all windows and switch then close
            List<string> allWindows = AutoDriver.WindowHandles.ToList();
            foreach (var window in allWindows)
            {
                if (window != parentWindowValue)
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
