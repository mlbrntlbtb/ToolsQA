using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.WrapperFactory;
using Xunit;

namespace ToolsQA.xUnit_Basics
{
    public class xUnitParameter : IDisposable
    {
        //Initialization
        public xUnitParameter()
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

        [Theory]
        [InlineData("https://demoqa.com/")]
        public void Test(string URL)
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(URL);
        }
    }
}
