using GoogleMapsUITests.Data;
using GoogleMapsUITests.Fixtures;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

[TestFixtureSource(typeof(DeviceData), nameof(DeviceData.SupportedMobileDevices))]
[Parallelizable(ParallelScope.Fixtures)]
public class MobileLocationSearchByName : CompatibilityTest
{
    public MobileLocationSearchByName(Device device) : base(device)
    {
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCityLocationNames))]
    public async Task SearchLocationByNameValidLocation(Location location)
    {
        var searchPage = new MobileSearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.ClickOnContinueOnWebsiteBtn();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchResultAsExpected(location.expectedResult), $"The location '{location.name}' should be displayed as '{location.expectedResult}', but it may either have appeared incorrectly or not at all.");
    }

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.InvalidLocationNames))]
    public async Task SearchLocationByNameInvalidLocation(Location location)
    {
        var searchPage = new MobileSearchPage(Page);

        await searchPage.OpenPage();
        await searchPage.ClickOnContinueOnWebsiteBtn();
        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isSearchLocationNotFound(), $"The no location found message should appear for location '{location.name}', but it did not appear.");
    }
}