using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumSelections
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form/"); //More preferred than driver.Url;

            //RadioButtons
            List<IWebElement> radioButtons = AutoDriver.FindElements(By.XPath("//input[@name='gender']")).ToList();

            //Select getting value of selected
            bool isRbSelected = radioButtons.ElementAt(0).Selected;

            if (!isRbSelected)
            {
                IWebElement radioButton1Label = radioButtons.ElementAt(0).FindElement(By.XPath(".//following-sibling::label")); //Click label instead since clicking input throws error
                radioButton1Label.Click();
            }
               

            //Select getting attribute value
            string rbValue = radioButtons.ElementAt(1).GetAttribute("value");
            if (rbValue.Equals("Female"))
            {
                IWebElement radioButton2Label = radioButtons.ElementAt(1).FindElement(By.XPath(".//following-sibling::label")); //Click label instead since clicking input throws error
                radioButton2Label.Click();
            }
                

            //Select getting css value
            IWebElement otherRadioButton = AutoDriver.FindElement(By.CssSelector("input[value=Other]"));
            IWebElement radioButton3Label = otherRadioButton.FindElement(By.XPath(".//following-sibling::label")); //Click label instead since clicking input throws error
            radioButton3Label.Click();
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
