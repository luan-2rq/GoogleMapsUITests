namespace GoogleMapsUITests.Pages;
public class SearchPage
{
    private IPage _page;
    public SearchPage(IPage page) => _page = page;
    private string url = "https://www.google.com/maps";

    private ILocator _searchBox => _page.Locator("#searchboxinput");
    private ILocator _searchBtn => _page.Locator("#searchbox-searchbutton");
    private ILocator _searchTitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e h1.DUwDvf.lfPIob:has-text('{expectedResult}')");
    private ILocator _searchSubtitleResultTxt(string expectedResult) => _page.Locator($"div.tAiQdd > div.lMbq3e > h2.bwoZTb:has-text('{expectedResult}')");
    private ILocator _searchAddressResultTxt(string expectedResult) => _page.Locator($"div.LCF4w > span.JpCtJf > span.DkEaL:has-text('{expectedResult}')");

    public async Task SearchLocation(string location)
    {
        await _searchBox.FillAsync(location);
        await _searchBtn.ClickAsync();
    }

    public async Task OpenPage()
    {
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

}
