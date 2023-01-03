using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System.Configuration;
using ToolsQA.PageObjectDesign.PageObjects;


namespace ToolsQA.PageObjectDesign.TestCases
{
    public class LoginToLoginPage
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
            AutoDriver.Url = ConfigurationManager.AppSettings["LoginPage"]; //Create config file "Environment.config" to store URL

            //Create instance of page object
            LoginPage loginPage = new LoginPage(AutoDriver);

            //Using methods on page object
            //loginPage.LoginCredentials("johnwick", "excommunicado");

            //Using method with test data on page object
            loginPage.LoginCredentialsUsingTestData(ConfigurationManager.AppSettings["TestSheetDataPath"]);
            loginPage.VerifyCredentials();
        }

        [TearDown]
        public void EndTest()
        {
            //AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
