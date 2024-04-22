using GoogleMapsUITests.Data;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

[Parallelizable(ParallelScope.Fixtures)]
public class LocationSeachByCoordinates : PageTest
{
    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidLocationDDCoordinates))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidLocationDMSCoordinates))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidLocationDMMCoordinates))]
    public async Task SearchLocationByCoordinatesValidLocation(Location location)
    {
        var mainPage = new SearchPage(Page);

        await mainPage.OpenPage();
        await mainPage.SearchLocation(location.name);

        Assert.IsTrue(await mainPage.isSearchAddressResultAsExpected(location.outputName), $"The coordinates '{location.name}' should be displayed as '{location.outputName}', but it may either have appeared incorrectly or not at all.");
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.InvalidLocationCoordinates))]
    public async Task SearchLocationByCoordinatesInvalidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchLocationNotFound(location.outputName), $"The no location found message should appear for location '{location.name}', but it did not appear.");
    }
}