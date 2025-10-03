using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class SliderController(InsureContext context) : Controller
{
    public IActionResult SliderList()
    {
        var values = context.Sliders.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateSlider()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateSlider(Slider slider)
    {
        context.Sliders.Add(slider);
        context.SaveChanges();
        return RedirectToAction("SliderList");
    }

    [HttpGet]
    public IActionResult UpdateSlider(int id)
    {
        var value = context.Sliders.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateSlider(Slider slider)
    {
        var value = context.Sliders.Update(slider);
        context.SaveChanges();
        return RedirectToAction("SliderList");
    }

    public IActionResult DeleteSlider(int id)
    {
        var value = context.Sliders.Find(id);
        context.Sliders.Remove(value);
        context.SaveChanges();
        return RedirectToAction("SliderList");
    }
}
