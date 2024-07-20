using Microsoft.Playwright;

namespace MiaProject.Pages 
{

    public class BasicPage
    {
        private readonly IPage _page;
        private readonly ILocator _schoolLink;

        public BasicPage(IPage page)
        {
            _page =page;
            _schoolLink = page.Locator("//a[contains(text(),'Online High School')]");
        }
        public async Task GoUrl()
        {
            await _page.GotoAsync("https://miacademy.co/#/",new PageGotoOptions { WaitUntil = WaitUntilState.Load });
        }
        public async Task GoLink()
        {
            await _schoolLink.ClickAsync();
        }

}
}