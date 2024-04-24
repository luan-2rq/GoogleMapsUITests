

using NUnit.Framework.Interfaces;

namespace GoogleMapsUITests.Helpers;

/// <summary>
/// The ScreenshotHelper class provides utility method for capturing screenshots during test execution.
/// It organizes these screenshots in a directory structure based on the test execution date and time, test fixture, and test scenarios.
/// Screenshots are named after the test name and id and are saved in either a 'Pass' or 'Failure' directory depending on the test result.
/// </summary>
public static class ScreenshotHelper
{
    private static string? curTestExecutionDateTime;

    public static async Task CaptureScreenshotOnFailure(IPage page, TestContext testContext)
    {
        bool _takeScreenshotOnTestCompletion = false;
        bool.TryParse(TestContext.Parameters["TakeScreenshotOnTestCompletion"], out _takeScreenshotOnTestCompletion);

        if (_takeScreenshotOnTestCompletion || testContext.Result.Outcome.Status == TestStatus.Failed)
        {
            string testResult = testContext.Result.Outcome.Status == TestStatus.Passed ? "Pass" : "Failure";

            if(curTestExecutionDateTime == null)
                curTestExecutionDateTime = DateTime.Now.ToString("yyyy-MM-dd:HH_mm_ss");

            string testFixture = testContext.Test.ClassName ?? "_";
            string testScenario = testContext.Test.MethodName ?? "_";

            string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots", curTestExecutionDateTime, testFixture, testScenario, testResult);
            Directory.CreateDirectory(screenshotDirectory);

            string screenshotPath = Path.Combine(screenshotDirectory, $"{testContext.Test?.Name}{testContext.Test?.ID}.png");

            await page.ScreenshotAsync(new() { Path = screenshotPath });
            TestContext.AddTestAttachment(screenshotPath, $"Screenshot on {testResult}");
        }
    }
}