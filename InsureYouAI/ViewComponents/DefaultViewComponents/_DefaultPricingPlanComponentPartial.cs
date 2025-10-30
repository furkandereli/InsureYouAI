using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultPricingPlanComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        //var values = context.PricingPlans.Where(x => x.IsFeature == true).ToList();
        var pricingPlan1 = context.PricingPlans.Where(x => x.IsFeature == true).FirstOrDefault();
        ViewBag.pricingPlan1Title = pricingPlan1.Title;
        ViewBag.pricingPlan1Price = pricingPlan1.Price;
        ViewBag.pricingPlan1Id = pricingPlan1.PricingPlanId;

        var pricingPlan2 = context.PricingPlans.Where(x => x.IsFeature == true).OrderByDescending(y => y.PricingPlanId).FirstOrDefault();
        ViewBag.pricingPlan2Title = pricingPlan2.Title;
        ViewBag.pricingPlan2Price = pricingPlan2.Price;
        ViewBag.pricingPlan2Id = pricingPlan2.PricingPlanId;

        var pricingPlanItems = context.PricingPlanItems.Where(x => x.PricingPlanId == pricingPlan1.PricingPlanId || x.PricingPlanId == pricingPlan2.PricingPlanId).ToList();

        return View(pricingPlanItems);
    }
}
