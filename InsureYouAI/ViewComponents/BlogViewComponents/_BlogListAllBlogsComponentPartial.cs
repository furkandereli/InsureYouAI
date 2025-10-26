using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListAllBlogsComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Articles
            .Include(x => x.Category)
            .Include(y => y.AppUser)
            .ToList();
        return View(values);
    }
}
