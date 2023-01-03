using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Configuration;
using ToolsQA.PageObjectDesign.PageObjects;
using ToolsQA.WrapperFactory;

namespace ToolsQA.PageObjectDesign.TestCases
{
    public class LoginUsingWebDriverFactory
    {
        [SetUp]
        public void Initialize()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.MaximizeBrowser();
        }

        [Test]
        public void Test()
        {
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["LoginPage"]);

            LoginPage loginPage = new LoginPage(WebDriverFactory.Driver);
            loginPage.LoginCredentialsUsingTestData(ConfigurationManager.AppSettings["TestSheetDataPath"]);
        }

        [TearDown]
        public void EndTest()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
