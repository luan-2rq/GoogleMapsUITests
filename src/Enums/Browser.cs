using System.Collections;
using System.Collections.Generic;

namespace GoogleMapsUITests.Enums;
public enum Browser
{
    Chromium,
    Firefox,
    WebKit
}

public class SupportedBrowsers : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable<Browser>)Enum.GetValues(typeof(Browser))).GetEnumerator();
    }
}
