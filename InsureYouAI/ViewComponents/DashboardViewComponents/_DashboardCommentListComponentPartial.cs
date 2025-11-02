using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardCommentListComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Comments.Include(x => x.AppUser).OrderByDescending(y => y.CommentId).Take(7).ToList();
        return View(values);
    }
}
