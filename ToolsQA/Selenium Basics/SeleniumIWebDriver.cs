using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumIWebDriver
    {
        IWebDriver AutoDriver;
        //Actions action;
        //IJavaScriptExecutor jsExecutor;
       [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
            //AutoDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            //action = new Actions(AutoDriver);
            //jsExecutor = (IJavaScriptExecutor)AutoDriver;
        }

        [Test]
        public void Test()
        {
            //Basics
            AutoDriver.Url = "https://demoqa.com/";

            string pageTitle = AutoDriver.Title.ToString();
            string pageUrl = AutoDriver.Url.ToString();
            int pageSourceLength = AutoDriver.PageSource.Length;

            Console.WriteLine("Page Title: [" + pageTitle + "]");
            Console.WriteLine("Page URL: [" + pageUrl + "]");
            Console.WriteLine("Page Source Length: [" + pageSourceLength.ToString() + "]");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
