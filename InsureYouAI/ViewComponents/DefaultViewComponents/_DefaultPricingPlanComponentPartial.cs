using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultPricingPlanComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.PricingPlans.Where(x => x.IsFeature == true).ToList();
        return View(values);
    }
}
