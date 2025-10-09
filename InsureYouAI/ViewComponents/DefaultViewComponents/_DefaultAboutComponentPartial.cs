using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultAboutComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.title = context.Abouts.Select(a => a.Title).FirstOrDefault();
        ViewBag.description = context.Abouts.Select(a => a.Description).FirstOrDefault();
        ViewBag.imageUrl = context.Abouts.Select(a => a.ImageUrl).FirstOrDefault();

        var aboutItemValues = context.AboutItems.ToList();

        return View(aboutItemValues);
    }
}
