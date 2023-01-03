using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using ToolsQA.TestDataAccess;
namespace ToolsQA.PageObjectDesign.PageObjects
{
    public class LoginPage
    {
        //SeleniumExtras.PageObjects.Core latest version is 4.3 > Selenium WebDriver and Support should be downgraded to 4.3
        IWebDriver driver;

        //Use FindsBy annotation to locate web elements
        [FindsBy(How = How.XPath, Using = "//input[@id='userName']")]
        //[CacheLookup] //Cache element the first time its found
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        //[CacheLookup]
        private IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='login']")]
        //[CacheLookup]
        private IWebElement Login { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='newUser']")]
        //[CacheLookup]
        private IWebElement NewUser { get; set; }

        //Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10))); //Alternative for explicit wait
        }

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

        //Verify actions
        public void VerifyCredentials()
        {
            Console.WriteLine("Username: [" + UserName.Text + "]");
            Console.WriteLine("Password: [" + PassWord.Text + "]");
        }
    }
}
