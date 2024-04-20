using GoogleMapsUITests.Data;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.LocationSearching;

public class LocationSearchTest : PageTest
{

    [SetUp]
    public void Setup()
    {
    
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.validLocations))]
    public async Task SearchLocation(Location location)
    {
        var mainPage = new MainPage(Page);

        await mainPage.OpenPage();
        await mainPage.SearchLocation(location.name);

        Assert.IsTrue(await mainPage.isSearchResultAsExpected(location.outputName));
    }
}