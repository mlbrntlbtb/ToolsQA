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
    public class SeleniumIAlert
    {
        IWebDriver AutoDriver;
        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize(); ;
        }

        [Test]
        public void Test()
        {
            AutoDriver.Url = "https://demoqa.com/alerts";

            //Handling simple alerts

            //Open alert
            IWebElement alertButton = AutoDriver.FindElement(By.Id("alertButton"));
            alertButton.Click();

            //Switch to alert
            IAlert simpleAlert = AutoDriver.SwitchTo().Alert();

            //Get value of alert
            string simpleAlertValue = simpleAlert.Text;
            Console.WriteLine("Simple Alert Value: [" + simpleAlertValue + "]");

            //Accept alert
            simpleAlert.Accept();

            //Handling confirmation alerts

            //Open alert
            IWebElement confirmButton = AutoDriver.FindElement(By.Id("confirmButton"));
            confirmButton.Click();

            //Switch to alert
            IAlert confirmAlert = AutoDriver.SwitchTo().Alert();

            //Get value of alert
            string confirmAlertValue = confirmAlert.Text;
            Console.WriteLine("Confirm Alert Value: [" + confirmAlertValue + "]");

            //Dismiss alert
            confirmAlert.Dismiss();

            //Handling prompt alerts

            //Open alert
            IWebElement promptButton = AutoDriver.FindElement(By.Id("promtButton"));
            promptButton.Click();

            //Switch to alert
            IAlert promptAlert = AutoDriver.SwitchTo().Alert();

            //Get value of alert
            string promptAlertValue = promptAlert.Text;
            Console.WriteLine("Prompt Alert Value: [" + simpleAlertValue + "]");

            //Enter value to prompt alert
            promptAlert.SendKeys("John Wick");

            //Accept alert
            promptAlert.Accept();
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
