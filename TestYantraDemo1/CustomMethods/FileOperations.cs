using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.CustomMethods
{
    public class FileOperations
    {

        // Create file at designated location with content
        public static void createFile(string fileName, string filecontent)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(filecontent);
            writer.Close();
        }

        // Create (if do not exist) or Appened file content
        public static void createFileAppend(string fileName, string filecontent)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(filecontent);
            writer.Close();

        }
        //Read file
        public static StreamReader ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            return reader;
        }

        // Get property of file
        public static string GetFileDeatils(string fileName, string propName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            String propValue = "";
            // Check if file exists
            if (fileInfo.Exists)
            {
                // Get file properties
                if (propName.Equals("Name")){
                    propValue = fileInfo.Name;
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
            return propValue;

        }
        //Get Json property
        public static string getJsonKeyValue(string fileName,string key)
        {
            return null;
        }

        // Read data from Excel
        public static string ReadExcelData(string filePath,int row,int col)
        {
            // Register an encoding provider
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Load Excel file into a FileStream
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Create an ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Move to the specified row
                    for (int i = 0; i < row; i++)
                    {
                        reader.Read();
                    }

                    // Move to the specified column
                    reader.Read(); // Move to the row

                    for (int i = 0; i < col; i++)
                    {
                        reader.Read(); // Move to the next cell
                    }

                    // Read the cell value
                    return reader.GetValue(col)?.ToString();
                }
            }
        }

    }
}
