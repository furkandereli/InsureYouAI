using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers;

public class CommentController(InsureContext context) : Controller
{

    public IActionResult CommentList()
    {
        var values = context.Comments.Include(x => x.AppUser).Include(y => y.Article).ToList();
        return View(values);
    }
}
