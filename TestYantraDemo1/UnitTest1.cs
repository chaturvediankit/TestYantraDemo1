using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

namespace TestYantraDemo1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
            

        }

        [Test]
        public void Test1()
        {
            String jsonContent = File.ReadAllText("AppSetings.json");
            JsonDocument doc = JsonDocument.Parse(jsonContent);
            JsonElement root = doc.RootElement;

            String url = root.GetProperty("UatUrl").GetString();

            IWebDriver driver = new ChromeDriver();
            
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            var element = driver.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']"));
           
            element.SendKeys("Shoes");

            //driver.Close();

           
        }

    
    }
}