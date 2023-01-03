using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumIJavaScriptExecutor
    {
        IWebDriver AutoDriver;
        IJavaScriptExecutor JavaScriptExecutor;

        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
            AutoDriver.Manage().Window.Maximize();
            JavaScriptExecutor = (IJavaScriptExecutor)AutoDriver;
            //JavaScriptExecutor = AutoDriver as IJavaScriptExecutor; "typecasting"
        }

        [Test]
        public void Test()
        {
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");

            //ExecuteScript
            //JavaScriptExecutor.ExecuteScript("<script>"); //Param arg can be empty

            //Scroll into view
            IWebElement targetElement = AutoDriver.FindElement(By.XPath("<sample_xpath>"));
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(false);", targetElement);

            //Page load completed
            bool readyState = JavaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete");

            //Ajax calls - Check if JQuery is active

            bool isJQueryActive = (Boolean)JavaScriptExecutor.ExecuteScript("return window.jQuery != undefined && jQuery.active==0");

            //Open browser tab
            JavaScriptExecutor.ExecuteScript("window.open();");

            //Click
            JavaScriptExecutor.ExecuteScript("arguments[0].click()", targetElement);

            //Alerts
            JavaScriptExecutor.ExecuteScript("alert('Hello');");

            //Scrolling
            IWebElement scrollElement = AutoDriver.FindElement(By.XPath("<sample_xpath>"));
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollTop += 100", scrollElement);

            IWebElement targetTable = AutoDriver.FindElement(By.XPath("<sample_xpath>"));
            int scrollYPos = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return arguments[0].scrollTop", targetTable));
            int scrollXPos = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return arguments[0].scrollLeft", targetTable));

            JavaScriptExecutor.ExecuteScript("arguments[0].scrollTop = 100", scrollElement);
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollLeft = 100", scrollElement);

            //Scroll height 
            int scrollHeight = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return arguments[0].scrollHeight", targetTable));

            //Client height
            int clientHeight = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return arguments[0].clientHeight", targetTable));

            //Inner Outer Height
            int OuterHeight = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return window.outerHeight"));
            int InnerHeight = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return window.innerHeight"));

            //Zoom level
            int zoomLevel = Convert.ToInt32(JavaScriptExecutor.ExecuteScript("return window.screen.deviceXDPI"));

            //Get check state value checkbox
            IWebElement targetCheckBox = AutoDriver.FindElement(By.XPath("<sample_xpath>"));
            string checkState = JavaScriptExecutor.ExecuteScript("return arguments[0].checked", targetCheckBox).ToString();

            //Display
            JavaScriptExecutor.ExecuteScript("arguments[0].style.display='block'", targetElement);
            JavaScriptExecutor.ExecuteScript("arguments[0].style.display='none'", targetElement);
            JavaScriptExecutor.ExecuteScript("arguments[0].style.visibility='visible'", targetElement);

            //Lose focus
            IWebElement activeElement = AutoDriver.FindElement(By.XPath("<sample_xpath>"));
            JavaScriptExecutor.ExecuteScript("document.activeElement.blur()", activeElement);

            //Set focus
            JavaScriptExecutor.ExecuteScript("arguments[0].focus();", targetElement);

            //Set attribute
            string attributeName = ""; string value = "";
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", targetElement, attributeName, value);

            //Get sibling node value
            string nodeVal = JavaScriptExecutor.ExecuteScript("return arguments[0].nextSibling.nodeValue", targetElement).ToString();
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            //AutoDriver.Quit(); //Close all open windows
        }
    }
}
