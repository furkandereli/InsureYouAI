using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailCommentListComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke(int id)
    {
        var values = context.Comments.Where(x => x.ArticleId == id && x.CommentStatus == "Yorum Onaylandı").Include(y => y.AppUser).ToList();
        return View(values);
    }
}
