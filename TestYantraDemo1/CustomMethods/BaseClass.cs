using AventStack.ExtentReports;
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
        protected IWebDriver driver;
        protected ExtentReportClass extentReport = new ExtentReportClass();

        [SetUp]
        public void SetUp()
        {
            extentReport.BeforeTest();
            //Navigate to application
            String browser = TestContext.Parameters.Get("browser");
            driver = CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            String url = TestContext.Parameters.Get("url");
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            extentReport.AfterTest(driver);
            //Closing browser and any other session such as database connection etc
            CloseBrowser(driver);
            driver.Dispose();
            

        }
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
            //options.AddArgument("--start-maximized");
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
        public static void EnterText(IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        // Custom Method for Selecting from a dropdown by text
        public static void SelectFromDropDownByText(IWebElement element, string selectText)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(selectText);
        }
        // Custom Method for Selecting from a dropdown using value
        public static void SelectFromDropDownByValue(IWebElement element, string inputValue)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByValue(inputValue);
        }

        // Custom Method for Selecting from a dropdown using index
        public static void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByIndex(index);
        }

        // Custom Method for Drag and drop. we need to specify the origin element and destination elements
        public static void DragAndDropItem(IWebDriver driver, IWebElement sourceElement, IWebElement destinationElement)
        {
            Actions action = new Actions(driver);
            action.ClickAndHold(sourceElement).MoveToElement(destinationElement).Release().Perform();
        }

        // Custom method for performing a click action
        public static void ActionClick(IWebDriver driver, IWebElement Element)
        {
            Actions action = new Actions(driver);
            action.Click(Element).Build().Perform();
        }
        // Custom method for hovering over an element and then clicking it
        public static void ActionHoverAndClick(IWebDriver driver, IWebElement ElementHover, IWebElement ElementClick)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(ElementHover).Click(ElementClick).Build().Perform();
        }

        // Custom method for scrolling into view of an element
        public static void ScrollIntoView(IWebDriver driver, IWebElement Element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
        }
        // Custom method for adding a think time or sleep
        public static void ThinkTime(int TimeInSeconds)
        {
            System.Threading.Thread.Sleep(TimeInSeconds * 1000);
        }


    }
}
