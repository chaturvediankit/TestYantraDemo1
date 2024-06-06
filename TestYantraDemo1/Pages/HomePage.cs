using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.Pages
{
     public class HomePage
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver1)
        {
            driver = driver1;

        }

        public IWebElement MakeAppointmentButton => driver.FindElement(By.Id("btn-make-appointment"));
        public IWebElement TopHamburgerMenu => driver.FindElement(By.Id("menu-toggle"));
        public IWebElement CloseHamburgerMenu => driver.FindElement(By.Id("menu-close"));
        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[text()='Home']"));
        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Login']"));
        public IWebElement ProfileLink => driver.FindElement(By.XPath("//a[text()='Profile']"));
        public IWebElement LogoutLink => driver.FindElement(By.XPath("//a[text()='Logout']"));

        public void NavigateLoginPage(bool IfHamburgerMenu)
        {
            if (IfHamburgerMenu)
            {
                TopHamburgerMenu.Click();
                LoginLink.Click();
            }
            else {
                MakeAppointmentButton.Click();
            }

        }
        // Logout from application
        public void LogoutApplication()
        {
            TopHamburgerMenu.Click();
            LogoutLink.Click();
        }

    }
}
