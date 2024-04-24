using GoogleMapsUITests.Helpers;
using NUnit.Framework.Interfaces;

namespace GoogleMapsUITests.Fixtures;


public class BaseTest : PageTest
{

    [TearDown]
    public async Task TearDown()
    {
        await ScreenshotHelper.CaptureScreenshotOnFailure(Page, TestContext.CurrentContext);
    }
}