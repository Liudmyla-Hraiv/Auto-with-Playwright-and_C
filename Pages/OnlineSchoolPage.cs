using Microsoft.Playwright;
using System.Threading.Tasks;

namespace MiaProject.Pages
{
 public class OnlineSchoolPage
 {
    private readonly IPage _page;
    private readonly ILocator _applyNowMenu;

    public OnlineSchoolPage(IPage page)
    {
        _page=page;
        _applyNowMenu = _page.GetByRole(AriaRole.Link, new() { Name = "Apply Now" });
    }
    public async Task GoApplyNow()
    {
        await _applyNowMenu.ClickAsync();
    }
 }   
}