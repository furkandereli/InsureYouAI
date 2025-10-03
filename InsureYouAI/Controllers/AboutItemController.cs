using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class AboutItemController(InsureContext context) : Controller
{
    public IActionResult AboutItemList()
    {
        var values = context.AboutItems.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateAboutItem()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateAboutItem(AboutItem aboutItem)
    {
        context.AboutItems.Add(aboutItem);
        context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }

    [HttpGet]
    public IActionResult UpdateAboutItem(int id)
    {
        var value = context.AboutItems.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateAboutItem(AboutItem aboutItem)
    {
        var value = context.AboutItems.Update(aboutItem);
        context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }

    public IActionResult DeleteAboutItem(int id)
    {
        var value = context.AboutItems.Find(id);
        context.AboutItems.Remove(value);
        context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }
}
