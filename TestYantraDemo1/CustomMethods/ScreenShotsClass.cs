using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace TestYantraDemo1.CustomMethods
{
    public class ScreenShotsClass
    {
        // Take Screen shots
        public static void CaptureScreenShot(IWebDriver driver, string testName)
        {
            try
            {
                // Get the directory of the executing assembly
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = Path.Combine(directory, "..", "..", "..");
                string testResultLocation = Path.Combine(path, "TestOutput", "FailedTests", DateTime.Today.ToString("dd-MM-yyyy"));
                Directory.CreateDirectory(testResultLocation);

                // Create a unique file name
                string imageName = $"{testName}_{DateTime.Now:yyyy-MM-dd-HH_mm_ss}.png";
                string imagePath = Path.Combine(testResultLocation, imageName);

                // Capture screenshot and save
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
               screenshot.SaveAsFile(imagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                Assert.Fail();

                // Close Browser
            }
        }

    }
}
