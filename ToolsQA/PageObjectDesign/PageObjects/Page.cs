using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.WrapperFactory;
using ToolsQA.PageObjectDesign.PageObjects;

namespace ToolsQA.PageObjectDesign.PageObjects
{
    public class Page
    {
        //Create generics -- way to create class/method/type without specifying type of parameters
        //Use generic type 'T' to be returned as output
        private static T GetPage<T>() where T : new() //Use contrains to restrict parameters to have default constructor/parameterless
        {
            var page = new T();
            //PageFactory.InitElements(WebDriverFactory.Driver, page);
            PageFactory.InitElements(page, new RetryingElementLocator(WebDriverFactory.Driver, TimeSpan.FromSeconds(10))); //Alternative for explicit wait
            return page;
        }

        public static LoginPageUsingPageFactory LoginPagePF
        {
            get
            {
                return GetPage<LoginPageUsingPageFactory>();
            }
        }

        public static LoginPageUsingExtensions LoginPageEXT
        {
            get
            {
                return GetPage<LoginPageUsingExtensions>();
            }
        }
    }
}
