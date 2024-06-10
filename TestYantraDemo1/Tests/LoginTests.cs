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


        [Test]
        public void LoginToApplication_Valid()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));

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
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            
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

            Assert.Fail("Failed on pupose to show in report");

            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(loginPage.InvalidLoginMessage));

        }

        [Test]
        public void LogoutFromApplication()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));


            homePage.LogoutApplication();
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(homePage.MakeAppointmentButton));

        }

    }
}
