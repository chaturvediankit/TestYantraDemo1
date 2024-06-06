using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYantraDemo1.CustomMethods;

namespace TestYantraDemo1.Pages
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement UsernameTextField => driver.FindElement(By.Id("txt-username"));
        public IWebElement PasswordTextField => driver.FindElement(By.Id("txt-password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("btn-login"));
        public IWebElement InvalidLoginMessage => driver.FindElement(By.XPath("//p[@class='lead text-danger']"));

        public void LoginApplication(String userName,String password)
        {
            try
            {
                BaseClass.EnterText(UsernameTextField, userName);
                BaseClass.EnterText(PasswordTextField, password);
                LoginButton.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine("Test Failed: Not able to enter details"+e.Message);
            }
        }



    }
}
