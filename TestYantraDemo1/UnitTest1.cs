using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.Text;
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
            Console.WriteLine(FileOperations.ReadExcelData("FinancialSample.xlsx", 8, 0));
        }




    }
}