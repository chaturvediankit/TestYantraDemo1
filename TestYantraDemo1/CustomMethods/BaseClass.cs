using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.CustomMethods
{
    public class BaseClass
    {
        //This will launch browser in desired configuration
        public static IWebDriver CreateWebDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    return CreateFirefoxDriver();

                case "chrome":
                    return CreateChromeDriver();
                case "edge":
                        return CreateEdgeDriver();
                default:
                    throw new ArgumentException("Invalid browser name");

            }
        }

        private static IWebDriver CreateEdgeDriver()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            return driver;

        }

        private static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);

        }

        private static IWebDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            return new FirefoxDriver(options);

        }

        //Close Browser Instance

        public static void CloseBrowser(IWebDriver driver)
        {
            try
            {
                driver.Quit();
               /* Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
                foreach(var process in chromeDriverProcesses)
                {
                    process.Kill();
                }*/

            }catch (Exception ex)
            {
                Console.WriteLine("Issue encountered while closing browser");
            }
        }

        //Custome method for entering a text in input field
        public void EnterText(IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }




    }
}
