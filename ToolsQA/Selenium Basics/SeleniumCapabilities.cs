using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Selenium_Basics
{
    public class SeleniumCapabilities
    {
        IWebDriver AutoDriver;
        ChromeOptions chromeOptions;
        FirefoxOptions firefoxOptions;
        ICapabilities capabilities;

        [SetUp]
        public void Initialize()
        {
            //Shared capabilities

            chromeOptions = new ChromeOptions();
            firefoxOptions = new FirefoxOptions();

            //chromeOptions.BrowserName = "Sample Browser Name";
            //firefoxOptions.BrowserName = "Sample Browser Name";

            //chromeOptions.BrowserVersion = "99";
            //firefoxOptions.BrowserVersion = "99";

            //chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal; //(Normal, Eager, None)
            //firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            //chromeOptions.PlatformName = "OS";
            //firefoxOptions.PlatformName = "0S";

            //chromeOptions.AcceptInsecureCertificates = true; //Accepts TLS or SSL certificates
            //firefoxOptions.AcceptInsecureCertificates = true;

            //chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss; //(Dismiss,Accept, DimissNotify, AcceptNotify, Ignore)
            //firefoxOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;

            //chromeOptions.UseStrictFileInteractability = true; //Checks for input type=file elements
            //firefoxOptions.UseStrictFileInteractability = true;

            //Proxy proxy = new Proxy(); //Capture traffic and access networks/url blocked that needs proxy to be accessed
            //proxy.Kind = ProxyKind.Manual;
            //proxy.IsAutoDetect = false;
            //proxy.SslProxy = "<HOST:PORT>";

            //chromeOptions.Proxy = proxy;
            //firefoxOptions.Proxy = proxy;


            //Chrome options -- more info chromium command line switches: https://peter.sh/experiments/chromium-command-line-switches/
            //chromeOptions.AddArgument("start-maximized"); //maximize
            //chromeOptions.AddArgument("incognito"); //opens in incognito
            //chromeOptions.AddArgument("headless"); //opens headless state
            //chromeOptions.AddArgument("--window-size=1920,1080"); //Set window size
            //chromeOptions.AddArgument("disable-extensions"); //disables existing extensions
            //chromeOptions.AddArgument("disable-popup-blocking"); //disables popups
            //chromeOptions.AddArgument("disable-default-apps"); //disables installation of default apps on first run
            //chromeOptions.AddArgument("make-default-browser"); //makes chrome default browser
            //chromeOptions.AddArgument("version"); //prints chrome version
            //chromeOptions.AddArgument("ignore-certificate-errors"); //ignores SSL certificates
            //chromeOptions.AddArgument("--silent"); //silent mode -- log nothing
            //chromeOptions.AddExcludedArgument("enable-automation"); //disables infobars e.g. chrome is being controlled..
            //chromeOptions.AddAdditionalOption("useAutomationExtension", false); //disables developer mode extensions
            //chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            //chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);


            //ICapabilities -- use for RemoteWebDriver
            //capabilities = chromeOptions.ToCapabilities();
            //capabilities = firefoxOptions.ToCapabilities();


            //Firefox options -- more info command line switches: http://kb.mozillazine.org/About:config_entries & http://kb.mozillazine.org/Category:Preferences
            //firefoxOptions.BrowserExecutableLocation = "<browser path>";
            //firefoxOptions.SetPreference("browser.fixup.alternate.enabled", false);
            //firefoxOptions.SetPreference("browser.download.useDownloadDir", false);
            //firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "<type of files>");


            //Firefox driver service
            //FirefoxDriverService fds = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //fds.HideCommandPromptWindow = true;
            //AutoDriver = new FirefoxDriver(fds, firefoxOptions, TimeSpan.FromMilliseconds(10000));
        }

        [Test]
        public void Test()
        {
            AutoDriver = new ChromeDriver(chromeOptions);
            AutoDriver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [TearDown]
        public void EndTest()
        {
            AutoDriver.Close();
            AutoDriver.Quit(); //Close all open windows
        }
    }
}
