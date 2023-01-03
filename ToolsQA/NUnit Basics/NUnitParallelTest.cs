using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.WrapperFactory;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace ToolsQA.NUnit_Basics
{
    [TestFixture("Chrome", "https://demoqa.com/")]
    [TestFixture("Firefox", "https://demoqa.com/")]
    public class NUnitParallelTest
    {
        private string _browserName;
        private string _URL;

        //Constructor
        public NUnitParallelTest(string browserName, string URL)
        {
            _browserName = browserName;
            _URL = URL;
        }

        [SetUp]
        public void Initialize()
        {
            WebDriverFactory.InitBrowser(_browserName);
            WebDriverFactory.Driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(_URL);
        }

        [TearDown]
        public void EndTest()
        {
            WebDriverFactory.Driver.Close();
            WebDriverFactory.Driver.Quit(); //Close all open windows
        }
    }
}
