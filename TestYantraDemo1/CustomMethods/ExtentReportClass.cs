using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYantraDemo1.CustomMethods
{
    public class ExtentReportClass
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public void BeforeTest()
        {
            if (_extent == null)
            {

                var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var actualPath = path.Substring(0, path.LastIndexOf("bin"));
                var projectPath = new Uri(actualPath).LocalPath;
                Directory.CreateDirectory(projectPath.ToString() + "Reports");
                var reportPath = projectPath + "Reports\\index.html";
                var htmlReporter = new ExtentSparkReporter(reportPath);

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    _test.Log(Status.Fail, "Test Failed");

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    _test.Log(Status.Warning, "Test Inconclusive");
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    _test.Log(Status.Skip, "Test Skipped");
                    break;
                default:
                    logstatus = Status.Pass;
                    _test.Log(Status.Pass, "Test Passed");
                    break;
            }
            _extent.Flush();
        }

    }
}
