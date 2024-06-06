using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.Pages
{
    public class MakeAppointmentPage
    {
        public IWebDriver driver;
        public MakeAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        
        public IWebElement MakeAppointmentHeader => driver.FindElement(By.XPath("//h2[text()='Make Appointment']"));
        public IWebElement FacilitySelect => driver.FindElement(By.Id("combo_facility"));
        public IWebElement MadicareProgramRdBtn => driver.FindElement(By.Id("radio_program_medicare"));
        public IWebElement VisitDateTextField => driver.FindElement(By.Id("txt_visit_date"));
        public IWebElement CommentsTextArea => driver.FindElement(By.Id("txt_comment"));
        public IWebElement BookAppointmentBtn => driver.FindElement(By.Id("btn-book-appointment"));

        public void BookApointment(string facilityName,string programName,string appointmentDate,string message)
        {

        }

    }
}
