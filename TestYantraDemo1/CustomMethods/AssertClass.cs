using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.CustomMethods
{
    public class AssertClass
    {
        public readonly IWebDriver driverForAssert;
        public AssertClass(IWebDriver driver)
        {
            driverForAssert = driver;

        }

        // Verify Element is Present 
        public void AssertElementIsPresent(IWebElement element)
        {
            try
            {
                Assert.IsTrue(IsElementPresent(element));
                Console.WriteLine("Element is present.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test Failed, No element {0} is found ", ex.Message);
                throw ex;
            }
        }

        // Checks if element is present, returns true or false
        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                driverForAssert.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                bool isDisplayed = element.Displayed;
                driverForAssert.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return isDisplayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element : {0}", ex.Message);
                return false;
            }
        }


        //Check element if it Contains Text 
        public void ContainsText(IWebElement element, string neededText)
        {
            string actualText = element.Text;
            try
            {
                Assert.IsTrue(actualText.Contains(neededText), "Text Mismatched");
                Console.WriteLine("Text Matched");
            }
            catch (Exception e)
            {
                Console.WriteLine("Text Mismatched : {0}", e.Message);
                throw e;
            }
        }
    }
}
