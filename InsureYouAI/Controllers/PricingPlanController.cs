using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class PricingPlanController(InsureContext context) : Controller
    {
        public IActionResult PricingPlanList()
        {
            var values = context.PricingPlans.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePricingPlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePricingPlan(PricingPlan pricingPlan)
        {
            context.PricingPlans.Add(pricingPlan);
            context.SaveChanges();
            return RedirectToAction("PricingPlanList");
        }

        [HttpGet]
        public IActionResult UpdatePricingPlan(int id)
        {
            var value = context.PricingPlans.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePricingPlan(PricingPlan pricingPlan)
        {
            var value = context.PricingPlans.Update(pricingPlan);
            context.SaveChanges();
            return RedirectToAction("PricingPlanList");
        }

        public IActionResult DeletePricingPlan(int id)
        {
            var value = context.PricingPlans.Find(id);
            context.PricingPlans.Remove(value);
            context.SaveChanges();
            return RedirectToAction("PricingPlanList");
        }
    }
}
