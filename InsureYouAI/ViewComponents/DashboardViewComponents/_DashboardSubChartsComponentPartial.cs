using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardSubChartsComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
