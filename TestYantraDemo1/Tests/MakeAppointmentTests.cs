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
        

        [Test]
        public void MakeAppointment_Tokyo_Medicare()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));

            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            makeAppointment.BookApointment("Tokyo", "Medicare", "06/06/2024", "Test yanta appointment");
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(makeAppointment.ApptConfirmationMessage));
        }
        [Test]
        public void MakeAppointment_Honkong_Medicare()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));

            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            makeAppointment.BookApointment("Honkong", "Medicare", "07/06/2024", "Test yanta appointment");
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(makeAppointment.ApptConfirmationMessage));

        }
        [Test]
        public void MakeAppointment_Seoul_Medicare()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateLoginPage(false);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));

            MakeAppointmentPage makeAppointment = new MakeAppointmentPage(driver);
            makeAppointment.BookApointment("Seoul", "Medicare", "07/06/2024", "Test yanta appointment");
            AssertClass assertClass = new AssertClass(driver);
            Assert.IsTrue(assertClass.IsElementPresent(makeAppointment.ApptConfirmationMessage));


        }


    }
}
