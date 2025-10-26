using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListLast3RecentBlogComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Articles.OrderByDescending(x => x.ArticleId).Take(3).ToList();
        return View(values);
    }
}
