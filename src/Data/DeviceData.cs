using GoogleMapsUITests.Enums;

namespace GoogleMapsUITests.Data;

/// <summary>
/// The DeviceData class contains methods for returning supported devices for running compatibility tests.
/// </summary>
public static class DeviceData {

    public static IEnumerable<Device> SupportedBrowsers() {

        yield return new Device { name ="Desktop Safari", browser = Browser.WebKit, channel="" };
        yield return new Device { name="Desktop Chrome", browser = Browser.Chromium, channel="chromium" };
        yield return new Device { name ="Desktop Firefox", browser = Browser.Firefox, channel="firefox" };
    }

    public static IEnumerable<Device> SupportedMobileDevices() {

        yield return new Device { name="Pixel 7", browser = Browser.Chromium, channel="" };
        yield return new Device { name ="iPhone 12", browser = Browser.WebKit, channel="" };
    }
}

public struct Device {

    public string name;
    public Browser browser;
    public string channel;
}