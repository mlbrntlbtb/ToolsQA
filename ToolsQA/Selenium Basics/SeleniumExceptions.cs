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
    public class SeleniumExceptions
    {
        IWebDriver AutoDriver;
        [SetUp]
        public void Initialize()
        {
            AutoDriver = new FirefoxDriver();
        }
        [Test]
        public void Test()
        {
            try
            {
                IWebElement findElement = AutoDriver.FindElement(By.XPath("//*[contains(@class,'some-element')]"));
            }
            catch (NoSuchElementException)
            {
                //InvalidSelectorException
                //The element is not present in the DOM when the search operation is performed.
            }
            catch (StaleElementReferenceException)
            {
                //The web element is present in the DOM when the search is initiated
                //but the element might have become stale (or its state in the DOM could have changed)
                //when the search call is made.
            }
            catch (ElementNotVisibleException)
            {
                //The web element is present in the DOM but it is not yet visible when the search process is initiated.
            }
            catch (ElementNotSelectableException)
            {
                //The element is present on the page but it cannot be selected.
            }
            catch (NoSuchFrameException)
            {
                //The WebDriver tries switching to a frame which is not a valid one.
            }
            catch (NoAlertPresentException)
            {
                //The WebDriver attempts switching to an alert window which is not yet available.
            }
            catch (NoSuchWindowException)
            {
                //The WebDriver attempts switching to a window that is not a valid one.
            }
            catch (TimeoutException)
            {
                //Using waits, this exception is thrown if the command did not execute or complete within wait time
            }
            catch (WebDriverException)
            {
                //UnhandledAlertException handled: Unexpected alert is displayed
                //Webdriver is acting immediately after ‘closing’ the browser
            }
        }
        
        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
