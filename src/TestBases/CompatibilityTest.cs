using GoogleMapsUITests.Data;
using GoogleMapsUITests.Helpers;
using Microsoft.Playwright.TestAdapter;

namespace GoogleMapsUITests.Fixtures;

/// <summary>
/// The CompatibilityTest class extends the PlaywrightTest class and is used as a base class for running compatibility tests on different devices.
/// It is passed a device in the constructor which is used to configure the viewport.
/// The class contains methods for setting up and tearing down the tests, as well as capturing screenshots on test failure.
/// </summary>
public class CompatibilityTest : PlaywrightTest
{
    private Device _device;
    public IBrowser? Browser;
    public IBrowserContext Context;
    public IPage Page;

    public CompatibilityTest(Device device)
    {
        _device = device;
    }

    [SetUp]
    public async Task SetUp()
    {
        switch (_device.browser)
        {
            case Enums.Browser.Chromium:
                Browser = await CreateBrowser(Playwright.Chromium, _device.channel);
                break;
            case Enums.Browser.Firefox:
                Browser = await CreateBrowser(Playwright.Firefox, _device.channel);
                break;
            case Enums.Browser.WebKit:
                Browser = await CreateBrowser(Playwright.Webkit, _device.channel);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var deviceConfig = Playwright.Devices[_device.name];
        Context = await Browser.NewContextAsync(deviceConfig);
        Page = await Context.NewPageAsync();
    }

    [TearDown]
    public async Task BrowserTearDown()
    {
        await ScreenshotHelper.CaptureScreenshotOnFailure(Page, TestContext.CurrentContext);

        await Context.CloseAsync();
        if (Browser != null)
            await Browser.CloseAsync();
    }

    public async Task<IBrowser> CreateBrowser(IBrowserType browserType, string channel) {
        var launchOptions = new BrowserTypeLaunchOptions(PlaywrightSettingsProvider.LaunchOptions);
        launchOptions.Channel = channel;
        return await browserType.LaunchAsync(launchOptions);
    }
}