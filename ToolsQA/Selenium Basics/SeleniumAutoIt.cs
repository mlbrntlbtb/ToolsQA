using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumAutoIt
    {
        IWebDriver AutoDriver;
        WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new ChromeDriver();
            AutoDriver.Manage().Window.Maximize();
            wait = new WebDriverWait(AutoDriver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            IWebElement chooseFile = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@for='uploadFile']")));
            chooseFile.Click();
            Process.Start("C:\\Users\\Melbourne\\Documents\\AutoITScripts\\FileUpload.exe"); //"File Upload" title of dialog when run to FF. "Open" in Chrome.
            Thread.Sleep(5000);
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
