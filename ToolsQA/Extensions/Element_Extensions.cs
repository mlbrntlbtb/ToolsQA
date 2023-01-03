using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Extensions
{
    public static class Element_Extensions
    {
        public static void EnterText(this IWebElement element, string text, string elementName)
        {
            element.Clear();
            element.SendKeys(text);
            Console.WriteLine("[" + text + "] entered in the [" + elementName + "] field.");
        }
    }
}
