using GoogleMapsUITests.Data;
using GoogleMapsUITests.Enums;
using GoogleMapsUITests.Fixtures;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class LocationSearchWithoutInternet : BaseTest
{

    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCountryLocationNames))]
    public async Task SearchLocationWithoutInternetValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();

        await searchPage.SearchLocation(location.name);

        await Page.Context.SetOfflineAsync(true);

        await searchPage.ClickOnSearchBtn();

        Assert.IsTrue(await searchPage.isInternetConnectionIssueDisplayed(), $"The connectivity issue should be displayed when trying to search without internet, but it did not appear.");
    }
}