using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class CategoryController(InsureContext context) : Controller
{
    public IActionResult CategoryList()
    {
        var values = context.Categories.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
        return RedirectToAction("CategoryList");
    }

    [HttpGet]
    public IActionResult UpdateCategory(int id)
    {
        var value = context.Categories.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateCategory(Category category)
    {
        var value = context.Categories.Update(category);
        context.SaveChanges();
        return RedirectToAction("CategoryList");
    }

    public IActionResult DeleteCategory(int id)
    {
        var value = context.Categories.Find(id);
        context.Categories.Remove(value);
        context.SaveChanges();
        return RedirectToAction("CategoryList");
    }
}
