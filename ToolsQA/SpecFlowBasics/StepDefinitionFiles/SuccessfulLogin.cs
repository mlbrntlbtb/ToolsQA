using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ToolsQA.SpecFlowBasics.StepDefinitionFiles
{
    [Binding]
    public class SuccessfulLogin
    {
		private WebDriver AutoDriver;
        private WebDriverWait wait;
        private string username = "johnwick";
        private string password = "Excommunicado123!";

		//Create methods base on SpecFlow Feature File
		[Given(@"User is on Login Page")]
		public void user_is_on_login_page()
		{
			AutoDriver = new ChromeDriver();
			wait = new WebDriverWait(AutoDriver, TimeSpan.FromSeconds(10));
			string targetURL = "https://demoqa.com/login";
			Console.WriteLine("Navigating to: [" + targetURL + "]");
			AutoDriver.Navigate().GoToUrl(targetURL);
		}

		[When(@"User enters UserName and Password")]
		public void user_enters_user_name_and_password()
		{
			IWebElement Username = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='userName']")));
			IWebElement Password = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='password']")));

			Console.WriteLine("Clearing login fields... ");
			Username.Clear();
			Password.Clear();

			Console.WriteLine("Setting username: [" + username + "]...");
			Username.SendKeys(username);

			Console.WriteLine("Setting password: [" + password + "]...");
			Password.SendKeys(password);
		}

		[When(@"Click Login")]
		public void click_login()
		{
			IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']]")));
			Console.WriteLine("Clicking login... ");
			Login.Click();
		}


		[Then(@"Userlabel with UserName will be displayed")]
		public void userlabel_with_user_name_will_be_displayed()
		{
			Console.WriteLine("Verify logged user label... ");
			IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
			string actualValue = Label.Text.Trim();
			Assert.Equals(actualValue, username);
		}
}
}
