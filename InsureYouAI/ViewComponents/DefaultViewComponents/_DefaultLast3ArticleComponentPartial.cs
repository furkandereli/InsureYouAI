using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultLast3ArticleComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Articles.OrderByDescending(x => x.ArticleId).Include(y => y.Category).Include(z => z.AppUser).Take(3).ToList();
        return View(values);
    }
}