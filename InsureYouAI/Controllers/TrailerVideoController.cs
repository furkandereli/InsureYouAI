using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class TrailerVideoController(InsureContext context) : Controller
{
    public IActionResult TrailerVideoList()
    {
        var values = context.TrailerVideos.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateTrailerVideo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateTrailerVideo(TrailerVideo trailerVideo)
    {
        context.TrailerVideos.Add(trailerVideo);
        context.SaveChanges();
        return RedirectToAction("TrailerVideoList");
    }

    [HttpGet]
    public IActionResult UpdateTrailerVideo(int id)
    {
        var value = context.TrailerVideos.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateTrailerVideo(TrailerVideo trailerVideo)
    {
        var value = context.TrailerVideos.Update(trailerVideo);
        context.SaveChanges();
        return RedirectToAction("TrailerVideoList");
    }

    public IActionResult DeleteTrailerVideo(int id)
    {
        var value = context.TrailerVideos.Find(id);
        context.TrailerVideos.Remove(value);
        context.SaveChanges();
        return RedirectToAction("TrailerVideoList");
    }
}
