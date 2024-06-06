using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYantraDemo1.CustomMethods;
using TestYantraDemo1.Pages;

namespace TestYantraDemo1.Tests
{
    public class LoginTests:BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            //Navigate to application
            String browser = TestContext.Parameters.Get("browser");
            driver = CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            String url=TestContext.Parameters.Get("url");
            driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void LoginToApplication_Valid()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            String username= TestContext.Parameters.Get("username");
            String password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username, password);

            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(makeAppointment.MakeAppointmentHeader));

        }
        [Test]
        public void LoginToApplication_HameburgerMenu_Valid()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(true);

            LoginPage loginPage = new LoginPage(driver);
            String username = TestContext.Parameters.Get("username");
            String password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username, password);

            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(makeAppointment.MakeAppointmentHeader));


        }
        [Test]
        public void LoginToApplication_Invalid()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            String username = TestContext.Parameters.Get("username");
            String password = TestContext.Parameters.Get("wrongPassword");
            loginPage.LoginApplication(username, password);

            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(loginPage.InvalidLoginMessage));

        }

        [Test]
        public void LogoutFromApplication()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            String username = TestContext.Parameters.Get("username");
            String password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username, password);

            homePage.LogoutApplication();
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(homePage.MakeAppointmentButton));

        }


        [TearDown]
        public void TearDown()
        {
            //Closing browser and any other session such as database connection etc
            CloseBrowser(driver);

        }


        

    }
}
