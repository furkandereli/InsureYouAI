using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class BlogController(InsureContext context) : Controller
{
    public IActionResult BlogList()
    {
        return View();
    }

    public IActionResult BlogDetail(int id)
    {
        ViewBag.i = id;
        return View();
    }

    public PartialViewResult GetBlog()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult GetBlog(string keyword)
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        comment.CommentDate = DateTime.Now;
        comment.AppUserId = "81bcb310-3fde-414a-85db-ec81d7af1c2b";

        context.Comments.Add(comment);
        context.SaveChanges();
        return RedirectToAction("BlogList");
    }
}
