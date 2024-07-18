using Microsoft.Playwright;

namespace MiaProject.Pages
{
    public class ParentPage
    {
        private readonly IPage _page;
        private readonly ILocator _firstName1;
        private readonly ILocator _lastName1;
        private readonly ILocator _email1;
        private readonly ILocator _dialCode;
        private readonly ILocator _phone1;
        private readonly ILocator _secondParent;
        private readonly ILocator _firstName2;
        private readonly ILocator _lastName2;
        private readonly ILocator _email2;
        private readonly ILocator _phone2;
        private readonly ILocator _searchEngine;
        private readonly ILocator _miaPrep;
        private readonly ILocator _miaAcademy;
        private readonly ILocator _alwaysIceCream;
        private readonly ILocator _cleverDragons;
        private readonly ILocator _facebookInstagram;
        private readonly ILocator _facebookMOHS;
        private readonly ILocator _facebookGeneral;
        private readonly ILocator _tikTok;
        private readonly ILocator _otherSocial;
        private readonly ILocator _wordOfmouth;
        private readonly ILocator _other;
        private readonly ILocator _startDate;
        private readonly ILocator _nextBtn;
        private readonly ILocator _backBtn;
    
        public ParentPage(IPage page)
        {
        _page=page;
        _firstName1 = _page.Locator("(//input[@name='Name'])[1]");
        _lastName1 = _page.Locator("(//input[@name='Name'])[2]");
        _email1 = _page.Locator("#Email-arialabel");
        _dialCode = _page.GetByTitle("United States: +");
        _phone1 = _page.Locator("#PhoneNumber");
        _secondParent = _page.GetByRole(AriaRole.Combobox, new() { Name = "-Select-" });
        _firstName2 = _page.Locator("(//input[@name='Name1'])[1]");
        _lastName2 = _page.Locator("(//input[@name='Name1'])[2]");
        _email2 = _page.Locator("#Email1-arialabel");
        _phone2 = _page.Locator("#PhoneNumber1");
        _searchEngine = _page.Locator("label[for='Checkbox_1']");
        _miaPrep = _page.Locator("label[for='Checkbox_2']");
        _miaAcademy = _page.Locator("label[for='Checkbox_3']");
        _alwaysIceCream = _page.Locator("label[for='Checkbox_4']");
        _cleverDragons = _page.Locator("label[for='Checkbox_5']");
        _facebookInstagram = _page.Locator("label[for='Checkbox_6']");
        _facebookMOHS = _page.Locator("label[for='Checkbox_7']");
        _facebookGeneral = _page.Locator("label[for='Checkbox_8']");
        _tikTok = _page.Locator("label[for='Checkbox_9']");
        _otherSocial = _page.Locator("label[for='Checkbox_10']");
        _wordOfmouth = _page.Locator("label[for='Checkbox_11']");
        _other = _page.Locator("label[for='Checkbox_12']");
        _startDate = _page.Locator("#Date-date");
        _nextBtn= _page.GetByLabel("Next Navigates to page 3 out of 4");
        _backBtn= _page.GetByLabel("Back Navigates to page 1 out of 4");
        }
        public async Task fillfirstParent(string first1, string last1, string em1,string code1, string ph1 )
        {
            await _firstName1.FillAsync(first1);
            await _lastName1.FillAsync(last1);
            await _email1.FillAsync(em1);
            await _dialCode.ClickAsync();
            await _page.GetByText(code1).ScrollIntoViewIfNeededAsync();
            await _page.GetByText(code1).ClickAsync();
            await _phone1.FillAsync(ph1);
           
        }
        public async Task addSecondParent(string yn)
        {
            await _secondParent.ClickAsync();
            var sp= _page.GetByRole(AriaRole.Treeitem, new() { Name = yn });
            await sp.ScrollIntoViewIfNeededAsync();
            await sp.ClickAsync();
        }
        public async Task fillSecondParent(string first2, string last2, string em2, string ph2 )
        {
            await _firstName2.FillAsync(first2);
            await _lastName2.FillAsync(last2);
            await _email2.FillAsync(em2);
            await _phone2.FillAsync(ph2);
        }
        public async Task check_searchEngine()
        {
           await _searchEngine.CheckAsync();
        }
        public async Task check_miaPrep()
        {
           await _miaPrep.CheckAsync();
        }
        public async Task check_miaAcademy()
        {
           await _miaAcademy.CheckAsync();
        }
        public async Task check_alwaysIceCream()
        {
           await _miaPrep.CheckAsync();
        }
        public async Task check_cleverDragons()
        {
           await _cleverDragons.CheckAsync();
        }
        public async Task check_facebookInstagram()
        {
           await _facebookInstagram.CheckAsync();
        }
        public async Task check_facebookMOHS()
        {
           await _facebookMOHS.CheckAsync();
        }
        public async Task check_facebookGeneral()
        {
           await _facebookGeneral.CheckAsync();
        }

        public async Task check_tikTok()
        {
           await _tikTok.CheckAsync();
        }
        public async Task check_otherSocial()
        {
           await _otherSocial.CheckAsync();
        }
        public async Task check_wordOfmouth()
        {
           await _wordOfmouth.CheckAsync();
        }
        public async Task check_other(){
           await _other.CheckAsync();
        }
        public async Task addStartData(String date){
           await _startDate.FillAsync(date);
           await _startDate.PressAsync("Enter");
        }
        public async Task GoToNextPage(){
           await _nextBtn.ClickAsync();
        }
        public async Task GoBackPage(){
           await _backBtn.ClickAsync();
        }

    } 
}  