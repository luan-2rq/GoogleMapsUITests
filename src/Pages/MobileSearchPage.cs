namespace GoogleMapsUITests.Pages;

/// <summary>
/// The MobileSearchPage class represents the mobile version of the Google Maps search page.
/// It contains the locators for the page elements and methods for interacting with them.
/// </summary>
public class MobileSearchPage
{
    private IPage _page;
    public MobileSearchPage(IPage page) => _page = page;

    private string _url = "https://www.google.com/maps";

    private ILocator _continueOnWebsiteBtn1 => _page.Locator("div.gZdUGf > span:nth-child(2) > button");
    private ILocator _continueOnWebsiteBtn2 => _page.Locator("div.uklSZe > div.Fo7Vnb > span:nth-child(1) > button.K2FXnd.Oz0bd.oNZ3af");
    
    private ILocator _searchBoxBtn => _page.Locator("div.mqxVAc > div.bVzuaf.QU7iXc > div.JdG3E");
    private ILocator _searchBox => _page.Locator("#ml-searchboxinput");
    private ILocator _searchTitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e h1.DUwDvf:has-text('{expectedResult}')");
    private ILocator _searchSubtitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e > h2.bwoZTb:has-text('{expectedResult}')");

    private ILocator _noResultsTxt => _page.Locator($"div.ml-snackbar-container.visible > div[role=\"alert\"] div.j9ygdd");
    
    public async Task OpenPage()
    {
        string url = TestContext.Parameters["MainUrl"] ?? _url;
        await _page.GotoAsync(url);
    }

    public async Task ClickOnContinueOnWebsiteBtn()
    {
        var clickOnContinue1 =  _continueOnWebsiteBtn1.ClickAsync();
        var clickOnContinue2 =  _continueOnWebsiteBtn2.ClickAsync();
        await Task.WhenAny(clickOnContinue1, clickOnContinue2);
    }

    public async Task SearchLocation(string location)
    {
        await _searchBoxBtn.ClickAsync();
        await _searchBox.FillAsync(location);
        await _searchBox.PressAsync("Enter");
    }

    public async Task<bool> isSearchResultAsExpected(string expectedResult)
    {
        try
        {
            var waitSearchTitleResult = _searchTitleResultTxt(expectedResult).WaitForAsync();
            var waitSearchSubtitleResult = _searchSubtitleResultTxt(expectedResult).WaitForAsync();
            await Task.WhenAny(waitSearchTitleResult, waitSearchSubtitleResult);
            return true;
        }catch (TimeoutException){

            return false;
        }
    }

    public async Task<bool> isSearchLocationNotFound()
    {
        try
        {
            await _noResultsTxt.WaitForAsync();
            return true;
        }catch (TimeoutException){

            return false;
        }
    }

}