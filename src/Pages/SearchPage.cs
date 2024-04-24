namespace GoogleMapsUITests.Pages;
public class SearchPage
{
    private IPage _page;
    public SearchPage(IPage page) => _page = page;

    private string _url = "https://www.google.com/maps";
    
    private ILocator _searchBox => _page.Locator("#searchboxinput");
    private ILocator _searchBtn => _page.Locator("#searchbox-searchbutton");
    private ILocator _menuBtn => _page.Locator("button[aria-label='Menu']");
    private ILocator _searchTitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e h1.DUwDvf:has-text('{expectedResult}')");
    private ILocator _searchSubtitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e > h2.bwoZTb:has-text('{expectedResult}')");
    private ILocator _searchAddressResultTxt(string expectedResult) => _page.Locator($"div.LCF4w > span.JpCtJf > span.DkEaL:has-text('{expectedResult}')");
    private ILocator _noResultsTxt => _page.Locator("div.m6QErb.WNBkOb div.Q2vNVc > i");
    private ILocator _connectivityIssueTxt => _page.Locator("#Ng57nc > div.hdeJwf.ymw5uf.Hk4XGb.TEYSPe > div.EoqU6d");

    public async Task SearchLocation(string location)
    {
        await _searchBox.FillAsync(location);
        await _searchBtn.ClickAsync();
    }

    public async Task OpenPage()
    {
        string url = TestContext.Parameters["MainUrl"] ?? _url;
        await _page.GotoAsync(url);
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

    public async Task<bool> isSearchAddressResultAsExpected(string expectedResult)
    {
        try
        {
            await _searchAddressResultTxt(expectedResult).WaitForAsync();
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

    public async Task<bool> isInternetConnectionIssueDisplayed()
    {
        try
        {
            await _connectivityIssueTxt.WaitForAsync();
            return true;
        }catch (TimeoutException){

            return false;
        }
    }

    public async Task ClickOnSearchBtn() => await _searchBtn.ClickAsync();
}