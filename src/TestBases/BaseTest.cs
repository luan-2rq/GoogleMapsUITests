using GoogleMapsUITests.Helpers;
using NUnit.Framework.Interfaces;

namespace GoogleMapsUITests.Fixtures;

/// <summary>
/// Base test class that contains the TearDown method to capture a screenshot on test failure.
/// </summary>
public class BaseTest : PageTest
{

    [TearDown]
    public async Task TearDown()
    {
        await ScreenshotHelper.CaptureScreenshotOnFailure(Page, TestContext.CurrentContext);
    }
}