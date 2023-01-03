using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumElementCommands
    {
        IWebDriver AutoDriver;
        WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
            wait = new WebDriverWait(AutoDriver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test()
        {
            //Navigate to target textbox
            AutoDriver.Url = "https://demoqa.com/text-box";

            //Locator for target textbox element
            string textBox_XPath = "//input[@id='userName']";
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(textBox_XPath)));

            //Displayed
            bool tbExists = textBox.Displayed;
            Console.WriteLine("Target TextBox exists: [" + tbExists.ToString() + "]");

            //Enabled
            bool tbEnabled = textBox.Enabled;
            Console.WriteLine("Target TextBox is enabled: [" + tbEnabled.ToString() + "]");

            //Click
            textBox.Click();
            Console.WriteLine("Target TextBox is clicked.");

            //Send-keys
            textBox.SendKeys("Juan Dela Cruz");
            Console.WriteLine("Target TextBox's value after send keys: [" + textBox.Text + "]");

            //Clear
            textBox.Clear();
            Console.WriteLine("Target TextBox's value after clear: [" + textBox.Text + "]");

            //Navigate to target checkbox
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/checkbox");

            //Locator for target checkbox element
            string checkBox_XPath = "//span[@class='rct-checkbox']";
            IWebElement checkBox = wait.Until(ExpectedConditions.ElementExists(By.XPath(checkBox_XPath)));

            checkBox.Click();
            //Selected
            bool cbSelected = checkBox.Selected;
            Console.WriteLine("Target CheckBox selected: [" + cbSelected.ToString() + "]");

            //Navigate to target form
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            //Locator for target form element
            string form_XPath = "//form[@id='userForm']";
            IWebElement form = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(form_XPath)));

            //Submit
            form.Submit();
            Console.WriteLine("User form submit executed.");

            //Locator for target submit element
            string submit_XPath = "//button[@id='submit']";
            IWebElement submit = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(submit_XPath)));

            //TagName
            string submitTag = submit.TagName;
            Console.WriteLine("Submit tag name: [" + submitTag + "]");

            //GetCssValue
            string submitGetCssBG = submit.GetCssValue("background-color");
            string submitGetCssFS = submit.GetCssValue("font-size");
            Console.WriteLine("Submit element background-color: [" + submitGetCssBG + "] with font-size: [" + submitGetCssFS +"]");

            //GetAttribute
            string submitGetAttribute = submit.GetAttribute("class");
            Console.WriteLine("Submit element class attribute value: [" + submitGetAttribute + "]");

            //Size
            Size size = submit.Size;
            Console.WriteLine("Submit element size < Height: [" + size.Height.ToString() + "] Width: [" + size.Width.ToString() + "] >");

            //Location
            Point point = submit.Location;
            Console.WriteLine("Submit element location < X-Coordinate: [" + point.X.ToString() + "] Y-Coordinate: [" + point.Y.ToString() + "] >");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
