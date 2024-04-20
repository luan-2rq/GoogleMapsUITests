namespace GoogleMapsUITests.Pages
{
    public class MainPage
    {

        private IPage _page;
        public MainPage(IPage page) => _page = page;

        private string url = "https://www.google.com/maps";
        private ILocator _searchBox => _page.Locator("#searchboxinput");
        private ILocator _searchBtn => _page.Locator("#searchbox-searchbutton");
        private ILocator _menuBtn => _page.Locator("button[aria-label='Menu']");
        private ILocator _searchSubtitleResult(string result) => _page.Locator($"h2.bwoZTb:has-text('{result}')");

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
                await _searchSubtitleResult(expectedResult).WaitForAsync();
                return true;
            }catch (TimeoutException){
                return false;
            }

        }
    }
}