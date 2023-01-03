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
    public class SeleniumWebTables
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
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/webtables"); //More preferred than driver.Url;

            string targetColumn = "Last Name";
            int targetRow = 1;

            IWebElement tableContainer = AutoDriver.FindElement(By.XPath("//div[@class='rt-table']"));
            List<IWebElement> tableHeaders = tableContainer.FindElements(By.XPath(".//div[contains(@class,'header-content')]")).Where(x => x.Displayed).ToList();
            List<IWebElement> tableRows = tableContainer.FindElements(By.XPath(".//div[contains(@class,'rt-tr-group')]")).Where(x => x.Displayed).ToList();
            int headerIndex = GetColumnHeaderIndex(tableHeaders, targetColumn);
            string cellValue = GetTargetCell(headerIndex, tableRows[targetRow]).Text.Trim();

            Console.WriteLine("Target cell with column: [" + targetColumn + "] and row: [" + targetRow + "] has value of: [" + cellValue + "]");
        }

        public int GetColumnHeaderIndex(List<IWebElement> tableHeaders, string targetHeader)
        {
            for(int h=0;h<tableHeaders.Count;h++)
            {
                IWebElement currentHeader = tableHeaders[h];
                string headerValue = !String.IsNullOrEmpty(currentHeader.Text) ? currentHeader.Text : currentHeader.GetAttribute("value");

                if (headerValue.Trim().Equals(targetHeader))
                    return h;
            }
            return -1;
        }

        public IWebElement GetTargetCell(int headerIndex, IWebElement targetRow)
        {
            List<IWebElement> tableCells = targetRow.FindElements(By.XPath(".//div[contains(@class,'rt-td')]")).Where(x=>x.Displayed).ToList();
            return tableCells[headerIndex];
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
        }
    }
}
