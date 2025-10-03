using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class ServiceController(InsureContext context) : Controller
{
    public IActionResult ServiceList()
    {
        var values = context.Services.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateService(Service service)
    {
        context.Services.Add(service);
        context.SaveChanges();
        return RedirectToAction("ServiceList");
    }

    [HttpGet]
    public IActionResult UpdateService(int id)
    {
        var value = context.Services.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateService(Service service)
    {
        var value = context.Services.Update(service);
        context.SaveChanges();
        return RedirectToAction("ServiceList");
    }

    public IActionResult DeleteService(int id)
    {
        var value = context.Services.Find(id);
        context.Services.Remove(value);
        context.SaveChanges();
        return RedirectToAction("ServiceList");
    }
}
