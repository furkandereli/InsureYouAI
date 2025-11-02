using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardRadialChartComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = context.Policies.Count();
        ViewBag.r1 = context.Policies.Where(x => x.Status == "Active").Count();
        return View();
    }
}
