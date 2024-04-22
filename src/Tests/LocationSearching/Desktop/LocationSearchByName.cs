using GoogleMapsUITests.Data;
using GoogleMapsUITests.Enums;
using GoogleMapsUITests.Fixtures;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

[TestFixtureSource(typeof(DeviceData), nameof(DeviceData.SupportedBrowsers))]
[Parallelizable(ParallelScope.Fixtures)]
public class LocationSearchByName : CompatibilityTest
{
    public LocationSearchByName(Device device) : base(device)
    {
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCountryLocationNames))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidStateLocationNames))]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCityLocationNames))]
    public async Task SearchLocationByNameValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchResultAsExpected(location.expectedResult), $"The location '{location.name}' should be displayed as '{location.expectedResult}', but it may either have appeared incorrectly or not at all.");
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidStreetLocationNames))]
    public async Task SearchLocationStreetAddressByNameValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchAddressResultAsExpected(location.expectedResult), $"The street '{location.name}' should be displayed as '{location.expectedResult}', but it may either have appeared incorrectly or not at all.");
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.InvalidLocationNames))]
    public async Task SearchLocationByNameInvalidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchLocationNotFound(), $"The no location found message should appear for location '{location.name}', but it did not appear.");
    }
}