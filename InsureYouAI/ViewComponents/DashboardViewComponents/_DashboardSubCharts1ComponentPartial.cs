using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardSubCharts1ComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var policyData = context.Policies
            .GroupBy(p => p.PolicyType)
            .Select(g => new
            {
                PolicyType = g.Key,
                Count = g.Count()
            }).ToList();

        ViewBag.policyData = JsonConvert.SerializeObject(policyData);      

        return View();
    }
}
