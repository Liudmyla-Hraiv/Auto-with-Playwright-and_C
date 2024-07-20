using Microsoft.Playwright;

namespace MiaProject.Pages
{
    public class NoteBeforeApplicationPage
    {
        private readonly IPage _page;
        private readonly ILocator _nextBtn;
        private readonly ILocator _takeQuiz;

        public NoteBeforeApplicationPage(IPage page)
        {
            _page = page;
            _nextBtn = _page.GetByLabel("Next Navigates to page 2 out of 4");
            _takeQuiz=_page.Locator("//span[text()='take this quiz']");
        }

        public async Task GoNextPage()
        {
            await _nextBtn.ClickAsync();
        }
        public async Task GoTakeQuiz()
        {
            await _takeQuiz.ClickAsync();
        }
    }
}