using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.Pages
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            driver = driver;

        }
        public IWebElement UsernameTextField => driver.FindElement(By.Id("txt-username"));

    }
}
