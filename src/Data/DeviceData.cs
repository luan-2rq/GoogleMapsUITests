using GoogleMapsUITests.Enums;

namespace GoogleMapsUITests.Data;
public static class DeviceData {

    public static IEnumerable<Device> SupportedBrowsers() {

        yield return new Device { name ="Desktop Safari", browser = Browser.WebKit, channel="" };
        yield return new Device { name="Desktop Chrome", browser = Browser.Chromium, channel="chromium" };
        yield return new Device { name ="Desktop Firefox", browser = Browser.Firefox, channel="firefox" };
    }
}

public struct Device {

    public string name;
    public Browser browser;
    public string channel;
}