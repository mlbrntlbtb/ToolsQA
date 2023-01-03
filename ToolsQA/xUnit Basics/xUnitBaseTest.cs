using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.WrapperFactory;
using Xunit;

namespace ToolsQA.xUnit_Basics
{
    public class xUnitBaseTest : IDisposable
    {
        //Initialization
        public xUnitBaseTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.Driver.Manage().Window.Maximize();
        }

        //De-initialization
        public void Dispose()
        {
            WebDriverFactory.Driver.Close();
            WebDriverFactory.Driver.Quit(); //Close all open windows
        }

        [Fact]
        public void Test()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl("https://demoqa.com/");
        }
    }
}
