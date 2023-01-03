using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.NUnit_Basics
{
    [TestFixture]
    public class NUnitBaseTest
    {
        IWebDriver AutoDriver;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new ChromeDriver();
            AutoDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
