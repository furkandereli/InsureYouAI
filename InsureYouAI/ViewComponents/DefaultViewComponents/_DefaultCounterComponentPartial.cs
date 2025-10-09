using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultCounterComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.categoryCount = context.Categories.Count();
        ViewBag.serviceCount = context.Services.Count();
        ViewBag.userCount = context.Users.Count();
        ViewBag.articleCount = context.Articles.Count();
        return View();
    }
}
