using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class ArticleController(InsureContext context) : Controller
{
    public IActionResult ArticleList()
    {
        var values = context.Articles.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateArticle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateArticle(Article article)
    {
        article.CreatedDate = DateTime.Now;
        context.Articles.Add(article);
        context.SaveChanges();
        return RedirectToAction("ArticleList");
    }

    [HttpGet]
    public IActionResult UpdateArticle(int id)
    {
        var value = context.Articles.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateArticle(Article article)
    {
        var value = context.Articles.Update(article);
        context.SaveChanges();
        return RedirectToAction("ArticleList");
    }

    public IActionResult DeleteArticle(int id)
    {
        var value = context.Articles.Find(id);
        context.Articles.Remove(value);
        context.SaveChanges();
        return RedirectToAction("ArticleList");
    }
}
