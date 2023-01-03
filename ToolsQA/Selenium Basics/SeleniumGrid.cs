using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumGrid
    {
        IWebDriver AutoDriver;
        ICapabilities capabilities;
        [SetUp]
        public void Initialize()
        {
            capabilities = new ChromeOptions().ToCapabilities();
            string node = "http://192.168.100.26:4444";
            AutoDriver = new RemoteWebDriver(new Uri(node), capabilities);
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");
            Thread.Sleep(5000);
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Quit();
        }
    }
}
