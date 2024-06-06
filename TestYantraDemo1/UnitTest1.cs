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
            Console.WriteLine(FileOperations.ReadExcelData("FinancialSample.xlsx", 0, 0));
        }










        [Test]
        public void Test2()
        {
            // Register an encoding provider
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Load Excel file into a FileStream
            using (var stream = File.Open("FinancialSample.xlsx", FileMode.Open, FileAccess.Read))
            {
                // Create an ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Read data from the first row of the Excel file
                    reader.Read(); // Move to the first row

                    // Print data from the first row
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"Column {i + 1}: {reader.GetValue(i)}");
                    }
                }
            }
        }


    }
}