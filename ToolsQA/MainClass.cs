using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ToolsQA.PageObjectDesign.TestCases;

namespace ToolsQA
{
    internal class MainClass
    {
        #region PUBLIC PROPERTIES

        public static IWebDriver AutoDriver { get; set; }

        #endregion

        #region PUBLIC METHODS
        
        public static void Main(string[] args)
        {
            AutoDriver = new ChromeDriver();
            AutoDriver.Url = "https://www.google.com/";
        }

        #endregion
    }
}
