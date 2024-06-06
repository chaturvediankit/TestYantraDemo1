using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.Text.Json;
using TestYantraDemo1.CustomMethods;

namespace TestYantraDemo1
{
    [TestFixture]
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
            
            

        }


        [Test]
        public void Test1()
        {
            

            String url = TestContext.Parameters.Get("url").ToString();
            Console.WriteLine("Url="+url);

            /*
            IWebDriver driver = BaseClass.CreateWebDriver("chrome");
            driver.Navigate().GoToUrl("https://www.flipkart.com");
            ScreenShotsClass.CaptureScreenShot(driver, "TestYantra");

            */
            
        }

    
    }
}