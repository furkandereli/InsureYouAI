using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultFooterLast2ArticleComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Articles.OrderByDescending(x => x.ArticleId).Skip(3).Take(2).ToList();
        return View(values);
    }
}
