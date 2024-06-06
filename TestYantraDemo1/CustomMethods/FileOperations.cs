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
        public static string ReadExcelData()
        {

            return null;
        }

    }
}
