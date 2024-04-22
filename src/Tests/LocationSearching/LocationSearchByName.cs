using GoogleMapsUITests.Data;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

public class LocationSeachByName : PageTest
{
    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCountryLocationNames))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidStateLocationNames))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCityLocationNames))]
    public async Task SearchLocationByNameValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchResultAsExpected(location.outputName), $"The location '{location.name}' should be displayed as '{location.outputName}', but it may either have appeared incorrectly or not at all.");
    }

    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidStreetLocationNames))]
    public async Task SearchLocationStreetAddressByNameValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchAddressResultAsExpected(location.outputName), $"The street '{location.name}' should be displayed as '{location.outputName}', but it may either have appeared incorrectly or not at all.");
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.InvalidLocationNames))]
    public async Task SearchLocationByNameInvalidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchLocationNotFound(location.outputName), $"The no location found message should appear for location '{location.name}', but it did not appear.");
    }
}