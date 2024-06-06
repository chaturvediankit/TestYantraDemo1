using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYantraDemo1.CustomMethods;
using TestYantraDemo1.Pages;

namespace TestYantraDemo1.Tests
{
    public class MakeAppointmentTests:BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            //Navigate to application
            String browser = TestContext.Parameters.Get("browser");
            driver = CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            String url = TestContext.Parameters.Get("url");
            driver.Navigate().GoToUrl(url);
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            String username = TestContext.Parameters.Get("username");
            String password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username, password);
        }

        [Test]
        public void MakeAppointment_Tokyo_Medicare()
        {
            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            makeAppointment.BookApointment("Tokyo", "Medicare", "06/06/2024", "Test yanta appointment");
            //Assert.IsTrue(assertClass.IsElementPresent(homePage.MakeAppointmentButton));
        }
        [Test]
        public void MakeAppointment_Honkong_Medicare()
        {


        }
        [Test]
        public void MakeAppointment_Seoul_Medicare()
        {


        }


        [TearDown]
        public void TearDown()
        {
            //Closing browser and any other session such as database connection etc
            //CloseBrowser(driver);

        }

    }
}
