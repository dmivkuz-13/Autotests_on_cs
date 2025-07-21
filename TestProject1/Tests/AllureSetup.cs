using NUnit.Framework.Constraints;
using OpenQA.Selenium.DevTools.V136.Autofill;
using System.Diagnostics;

namespace Autotests_on_cs.Tests;

[SetUpFixture]
public class AllureSetup
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var resultDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "allure-results");
        if (Directory.Exists(resultDir))
            Directory.Delete(resultDir, true);
    }

    [OneTimeTearDown]
    public void GenerateAndOpenAllureReport()
    {
        try
        {
            var currentDir = TestContext.CurrentContext.TestDirectory;
            var resultDir = Path.Combine(currentDir, "allure-results");
            var reportDir = Path.Combine(currentDir, "allure-report");

            ProcessStartInfo processSettings = new()
            {
                FileName = "cmd.exe",
                Arguments = "/K allure serve",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            Process.Start(processSettings);
        }
        catch(Exception ex)
        {
            TestContext.WriteLine($"Failed to generate Allure report: {ex.Message}");
        }
    }
}
