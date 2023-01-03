using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.TestDataAccess;

namespace ToolsQA.PageObjectDesign.PageObjects
{
    public class LoginPageUsingPageFactory
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='userName']")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        private IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='login']")]
        private IWebElement Login { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='newUser']")]
        private IWebElement NewUser { get; set; }

        //No constructor needed. It will be included on page factory

        //Login actions
        public void LoginCredentials(string username, string password)
        {
            UserName.SendKeys(username);
            PassWord.SendKeys(password);
            Login.Click();
        }

        //Login action using excel test data
        public void LoginCredentialsUsingTestData(string filePath)
        {
            CSVHelper testData = new CSVHelper(filePath);
            string username = testData.GetTargetValue("Username");
            string password = testData.GetTargetValue("Password");
            UserName.SendKeys(username);
            PassWord.SendKeys(password);
            Login.Click();
        }
    }
}
