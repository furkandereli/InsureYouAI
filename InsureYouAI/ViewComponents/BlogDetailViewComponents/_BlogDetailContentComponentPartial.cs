using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailContentComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke(int id)
    {
        var values = context.Articles.Where(x => x.ArticleId == id).FirstOrDefault();
        return View(values);
    }
}
