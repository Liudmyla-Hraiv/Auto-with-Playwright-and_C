using Microsoft.Playwright;

namespace MiaProject.Pages
{
    public class StudentPage
    {   
        private readonly IPage _page;
        private readonly ILocator _countStudents;
        
 // For first student
        private readonly ILocator _firstName1;
        private readonly ILocator _lastName1;
        private readonly ILocator _preferName1;
        private readonly ILocator _email1;
        private readonly ILocator _phone1;
        private readonly ILocator _consent1;
        private readonly ILocator _dataOfBirth1;

        private readonly ILocator _gender1;

        private readonly ILocator _miaAcc1;

        private readonly ILocator _schooling1;
        private readonly ILocator _gradeCompleted1;
        private readonly ILocator _flexSchedule1;
        private readonly ILocator _moreInform1;
        private readonly ILocator _challenges1;
 // For second student
        private readonly ILocator _firstName2;
        private readonly ILocator _lastName2;
        private readonly ILocator _preferName2;
        private readonly ILocator _email2;
        private readonly ILocator _phone2;
        private readonly ILocator _consent2;

        private readonly ILocator _dataOfBirth2;

        private readonly ILocator _gender2;

        private readonly ILocator _miaAcc2;
        private readonly ILocator _schooling2;
        private readonly ILocator _gradeCompleted2;
        private readonly ILocator _flexSchedule2;
        private readonly ILocator _moreInform2;
        private readonly ILocator _challenges2;
//Common
        private readonly ILocator _nextBtn;
        private readonly ILocator _backBtn;
    public StudentPage(IPage page)
    {
        _page = page;
        _countStudents = _page.Locator("#select2-Dropdown1-arialabel-container");
 // For first student
        _firstName1 = _page.Locator("(//input[@name='Name2'])[1]");
        _lastName1 =  _page.Locator("(//input[@name='Name2'])[2]");
        _preferName1 = _page.Locator("#SingleLine5-arialabel");
        _email1 = _page.Locator("#Email2-arialabel");
        _phone1  = _page.Locator("#PhoneNumber2");
        _consent1 = _page.Locator("#select2-Dropdown2-arialabel-container");
        _dataOfBirth1 = _page.Locator("#Date3-date");
        _gender1 = _page.Locator("#select2-Dropdown3-arialabel-container");
        _miaAcc1 = _page.Locator("#select2-Dropdown4-arialabel-container").GetByText("-Select-"); 
        _schooling1 = _page.Locator("#select2-Dropdown5-arialabel-container");
        _gradeCompleted1 = _page.Locator("#Number1-arialabel");
        _flexSchedule1 = page.Locator("label[for='Checkbox7_1']");
        _moreInform1 = page.Locator("label[for='Checkbox7_6']");
        _challenges1 = _page.Locator("#select2-Dropdown13-arialabel-container");
//For Second Student
        _firstName2 = _page.Locator("(//input[@name='Name3'])[1]");
        _lastName2 =  _page.Locator("(//input[@name='Name3'])[2]");
        _preferName2 = _page.Locator("#SingleLine6-arialabel");
        _email2 = _page.Locator("#Email3-arialabel");
        _phone2  = _page.Locator("#PhoneNumber3");
        _consent2 = _page.Locator("#select2-Dropdown6-arialabel-container");
        _dataOfBirth2 = _page.Locator("#Date4-date");
        _gender2 = _page.Locator("#select2-Dropdown7-arialabel-container").GetByText("-Select-");
        _miaAcc2 = _page.Locator("#select2-Dropdown8-arialabel-container").GetByText("-Select-");
        _schooling2 = _page.Locator("#select2-Dropdown9-arialabel-container").GetByText("-Select-");
        _gradeCompleted2 = _page.Locator("#Number-arialabel");
        _flexSchedule2 = page.Locator("label[for='Checkbox8_1']");
        _moreInform2 = page.Locator("label[for='Checkbox8_6']");
        _challenges2 = _page.Locator("#select2-Dropdown14-arialabel-container");
//Common
        _nextBtn= _page.GetByLabel("Next Navigates to page 4 out of");
        _backBtn= _page.GetByLabel("Back Navigates to page 3 out of");

    } 
    public async Task oneOrTwoStudents(string count)
    {
        await _countStudents.ClickAsync();
        var c = _page.GetByRole(AriaRole.Treeitem, new() { Name = count });
        await c.ScrollIntoViewIfNeededAsync();
        await c.ClickAsync();
    } 

    public async Task fillFirstChildren(string fn1, string ln1, string pn1, string e1, string p1, string db1 )
    {
        await _firstName1.FillAsync(fn1);
        await _lastName1.FillAsync(ln1);
        await _preferName1.FillAsync(pn1);
        await _email1.FillAsync(e1);
        await _phone1.FillAsync(p1);
        await _dataOfBirth1.FillAsync(db1);
        await _dataOfBirth1.PressAsync("Enter");
    }
    public async Task fillConsentIfVisible1(string c1)
    {
        if (await _consent1.IsVisibleAsync())
        {
        await _consent1.ClickAsync();
        var con= _page.GetByRole(AriaRole.Treeitem, new() { Name = c1 });
        await con.ScrollIntoViewIfNeededAsync();
        await con.ClickAsync();
        }
    }
    public async Task MaleOrFemaleOrOther1(string gen)
    {
        await _gender1.ClickAsync();
        var g=_page.GetByRole(AriaRole.Treeitem, new() { Name = gen });
        await g.ScrollIntoViewIfNeededAsync();
        await g.ClickAsync();
    }
        public async Task miaAcc1(string yn)
    {
        await _miaAcc1.ClickAsync();
        var m=_page.GetByRole(AriaRole.Treeitem, new() { Name = yn });
        await m.ScrollIntoViewIfNeededAsync();
        await m.ClickAsync();
    }

 //Can be : "Homeschool" , "Public/Charter School", "Private School" 
    public async Task addSchooling1(string school)
    {
        await _schooling1.ClickAsync();
        var _s= _page.GetByRole(AriaRole.Treeitem, new() { Name = school });
        await _s.ScrollIntoViewIfNeededAsync();
        await _s.ClickAsync();
    }
    public async Task gradeCompleted1(string grade)
    {
        await _gradeCompleted1.ScrollIntoViewIfNeededAsync();
        await _gradeCompleted1.FillAsync(grade);
    }

    public async Task check_flexSchedule1()
    {
        await _flexSchedule1.CheckAsync();
    }
    
    public async Task check_moreInform1()
    {
        await _moreInform1.CheckAsync();
    }
    public async Task Challenges1(string yn)
    {   
        await _challenges1.ScrollIntoViewIfNeededAsync();
        await _challenges1.ClickAsync();
        var g=_page.GetByRole(AriaRole.Treeitem, new() { Name = yn });
        await g.ScrollIntoViewIfNeededAsync();
        await g.ClickAsync();
    }

    public async Task fillSecondChildren(string fn2, string ln2, string pn2, string e2, string p2, string db2 )
    {
        await _firstName2.ScrollIntoViewIfNeededAsync();
        await _firstName2.FillAsync(fn2);
        await _lastName2.FillAsync(ln2);
        await _preferName2.FillAsync(pn2);
        await _email2.FillAsync(e2);
        await _phone2.FillAsync(p2);
        await _dataOfBirth2.FillAsync(db2);
        await _dataOfBirth2.PressAsync("Enter");
    }
        public async Task fillConsentIfVisible2(string c2)
    {
        if (await _consent2.IsVisibleAsync())
        {
        await _consent2.ClickAsync();
        var con= _page.GetByRole(AriaRole.Treeitem, new() { Name = c2 });
        await con.ScrollIntoViewIfNeededAsync();
        await con.ClickAsync();
        }
    }
        public async Task MaleOrFemaleOrOther2(string gen)
    {
        await _gender2.ClickAsync();
        var g=_page.GetByRole(AriaRole.Treeitem, new() { Name = gen , Exact = true});
        await g.ScrollIntoViewIfNeededAsync();
        await g.ClickAsync();
    }
//TODO : mia "Monthly", "Annual", "Lifetime"
        public async Task miaAcc2(string yn)
    {   
        await _miaAcc2.ScrollIntoViewIfNeededAsync();
        await _miaAcc2.ClickAsync();
        var m=_page.GetByRole(AriaRole.Treeitem, new() { Name = yn });
        await m.ScrollIntoViewIfNeededAsync();
        await m.ClickAsync();
    }

 //Can be : "Homeschool" , "Public/Charter School", "Private School" 
    public async Task addSchooling2(string school)
    {
        await _schooling2.ScrollIntoViewIfNeededAsync();
        await _schooling2.ClickAsync();
        var _s= _page.GetByRole(AriaRole.Treeitem, new() { Name = school });
        await _s.ScrollIntoViewIfNeededAsync();
        await _s.ClickAsync();
    }
    public async Task gradeCompleted2(string grade)
    {
        await _gradeCompleted2.ScrollIntoViewIfNeededAsync();
        await _gradeCompleted2.FillAsync(grade);
    }
    public async Task check_flexSchedule2()
    {
        await _flexSchedule2.CheckAsync();
    }
    
    public async Task check_moreInform2()
    {
        await _moreInform2.CheckAsync();
    }
    public async Task Challenges2(string yn)
    {
        await _challenges2.ScrollIntoViewIfNeededAsync();
        await _challenges2.ClickAsync();
        var g=_page.GetByRole(AriaRole.Treeitem, new() { Name = yn });
        await g.ScrollIntoViewIfNeededAsync();
        await g.ClickAsync();
    } 
//Common
    public async Task GoToNextPage()
    {
    await _nextBtn.ClickAsync();
    }
    public async Task GoBackPage()
    {
    await _backBtn.ClickAsync();
    }
    }
}