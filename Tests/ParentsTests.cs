using Microsoft.Playwright;
using NUnit.Framework;
using MiaProject.Pages;
using System.Threading.Tasks;


namespace  MiaProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
     public class PlaywrightTests2
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
        [TearDown]
        public async Task Teardown()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

    [Test]
    public async Task Parent_errorLastName()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","","test@example.com","+49","1551515888");
        await _parentPage.GoToNextPage();
        var errorMsg= await _parentPage.GetErrorNameMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a value for this field."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
        public async Task Parent_errorFirstName()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("","Muller","test@example.com","+49","1551515888");
        var errorMsg= await _parentPage.GetErrorNameMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a value for this field."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
        public async Task Parent_errorEmail_1()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","","+49","1551515888");
        var errorMsg= await _parentPage.GetErrorEmailMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a value for this field."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
        public async Task Parent_errorEmail_2()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink(); 
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test","+49","1551515888");
        var errorMsg= await _parentPage.GetErrorEmailMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a valid email address. (eg: yourname@domain.com)"));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorEmail_3()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.","+49","1551515888");
        var errorMsg= await _parentPage.GetErrorEmailMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a valid email address. (eg: yourname@domain.com)"));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorPhone_1()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink(); 
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","", "");
        var errorMsg= await _parentPage.GetErrorPhoneMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a number for this field."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorPhone_2()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","+35", "12345678");
        var errorMsg= await _parentPage.GetErrorPhoneMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter only numbers."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
     [Test]
    public async Task Parent_errorPhone_3()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","", "+1222322522");
        var errorMsg= await _parentPage.GetErrorPhoneMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a number for this field."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
        public async Task Parent_errorPhone_4()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","+49", "12345678");
        await _parentPage.GetPhoneNumber1("1234567812345678");
        var errorMsg= await _parentPage.GetErrorPhoneMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Maximum limit: 15 digits."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorDate_1()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow(); 
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","+49","12345678");
        await _parentPage.addSecondParent("No");
        await _parentPage.GoToNextPage();
        var errorMsg= await _parentPage.GetErrorDateMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Choose a date."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorDate_2()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl(); 
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","+49","12345678");
        await _parentPage.addSecondParent("No");
        await _parentPage.addStartData("31-Sep-2024");
        await _parentPage.addStartData("31-Sep-2024");
        await _parentPage.GoToNextPage();
        var errorMsg= await _parentPage.GetErrorDateMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Enter a valid date."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    [Test]
    public async Task Parent_errorDate_3()
    {
        BasicPage _basicPage = new BasicPage(_page);
        OnlineSchoolPage _onlineSchoolPage = new OnlineSchoolPage(_page);
        NoteBeforeApplicationPage _noteBeforeApplicationPage = new NoteBeforeApplicationPage(_page);
        ParentPage _parentPage = new ParentPage(_page);
        await _basicPage.GoUrl();
        await _basicPage.GoLink();
        await _onlineSchoolPage.GoApplyNow();
        await _noteBeforeApplicationPage.GoNextPage();
        await _parentPage.fillfirstParent("Linda","Muller","test@example.com","+49","12345678");
        await _parentPage.addSecondParent("No");
        await _parentPage.addStartData("02-Oct-2024");
        await _parentPage.addStartData("02-Oct-2024");
        await _parentPage.GoToNextPage();
        var errorMsg= await _parentPage.GetErrorDateMsgAsync();
        Assert.That(errorMsg, Is.EqualTo("Choose a date on or before 01-Sep-2024."));
        Console.WriteLine($"{TestContext.CurrentContext.Test.Name} - {errorMsg}");
    }
    }
}