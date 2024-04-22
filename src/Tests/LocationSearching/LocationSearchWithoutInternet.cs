using System.Xml.Serialization;
using GoogleMapsUITests.Data;
using GoogleMapsUITests.Pages;

namespace GoogleMapsUITests.Tests.LocationSearching;

[Parallelizable(ParallelScope.Fixtures)]
public class LocationSearchWithoutInternet : PageTest
{
    [Test]
    [TestCaseSource(typeof(SearchLocationData), nameof(SearchLocationData.ValidCountryLocationNames))]
    public async Task SearchLocationWithoutInternetValidLocation(Location location)
    {
        var searchPage = new SearchPage(Page);

        await searchPage.OpenPage();

        await Page.Context.SetOfflineAsync(true);

        await searchPage.SearchLocation(location.name);

        Assert.IsTrue(await searchPage.isInternetConnectionIssueDisplayed(location.outputName), $"The connectivity issue should be displayed when trying to search without internet, but it did not appear.");
    }
}