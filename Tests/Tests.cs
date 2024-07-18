using Microsoft.Playwright;
using NUnit.Framework;
using MiaProject.Pages;

namespace  MiaProject.Tests
{
     public class PlaywrightTests
    {
        private IBrowser _browser;
        private IPage _page;
        private IPlaywright _playwright;
  

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
        }

    [Test]
    public async Task ValidSignIn()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        StudentPage _studentPage = new StudentPage(_page);

        await _basicPage.GoUrl();
        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\BasicPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken basic page.");
        await _basicPage.GoLink();

        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\OnlineSchoolPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken online-school page.");
        await _onlineSchoolPage.GoApplyNow();

        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\NoteBeforeApplicationPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken note before application page.");
        await _noteBeforeApplicationPage.GoNextPage();

//First Parent
        await _parentPage.fillfirstParent("Linda","Miller","test@example.com","Germany (Deutschland)","1551515888");
//Second Parent
        await _parentPage.addSecondParent("Yes");
        await _parentPage.fillSecondParent("Jhon", "Miller","test@example.com","+491551515777" );
//Common Data
        await _parentPage.check_facebookInstagram();
        await _parentPage.check_tikTok();
        await _parentPage.addStartData("01-Aug-2024");
        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\ParentPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken parent page.");
        await _parentPage.GoToNextPage();

        await _studentPage.oneOrTwoStudents("Two");
//Firt Children
        await _studentPage.fillFirstChildren("Milana", "Muller", "Mila", "test@example.com", "+491551515111" , "11-May-2015" );
        await _studentPage.fillConsentIfVisible1("Yes");
        await _studentPage.MaleOrFemaleOrOther1("Female");
        await _studentPage.miaAcc1("Yes");
        await _studentPage.addSchooling1("Private School");
        await _studentPage.gradeCompleted1("65");

        await _studentPage.Challenges1("No");
        await _studentPage.check_moreInform1();
        await _studentPage.check_flexSchedule1();
//Second Children
        await _studentPage.fillSecondChildren("Oliver", "Muller", "Olivar", "test@example.com", "+491551515222", "11-Dec-2012" );
        await _studentPage.fillConsentIfVisible2("No");
        await _studentPage.MaleOrFemaleOrOther2("Male");
        await _studentPage.miaAcc2("No");
        await _studentPage.addSchooling2("Homeschool");
        await _studentPage.gradeCompleted2("5");
        await _studentPage.check_moreInform2();
        await _studentPage.check_flexSchedule2();
        await _studentPage.Challenges2("Yes");
        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\StudentPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken student page.");
        await _studentPage.GoToNextPage();
        await Task.Delay(2000); 
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "C:\\Documents\\MiaProject\\Screenshots\\FinancialPage_fullScreen.png", FullPage = true });
        Console.WriteLine("Screenshot taken financial page.");
    }
    }
}