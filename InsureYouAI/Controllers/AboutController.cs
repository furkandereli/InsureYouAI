using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace InsureYouAI.Controllers;

public class AboutController(InsureContext context) : Controller
{
    public IActionResult AboutList()
    {
        var values = context.Abouts.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateAbout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateAbout(About about)
    {
        context.Abouts.Add(about);
        context.SaveChanges();
        return RedirectToAction("AboutList");
    }

    [HttpGet]
    public IActionResult UpdateAbout(int id)
    {
        var value = context.Abouts.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult UpdateAbout(About about)
    {
        var value = context.Abouts.Update(about);
        context.SaveChanges();
        return RedirectToAction("AboutList");
    }

    public IActionResult DeleteAbout(int id)
    {
        var value = context.Abouts.Find(id);
        context.Abouts.Remove(value);
        context.SaveChanges();
        return RedirectToAction("AboutList");
    }

    [HttpGet]
    public async Task<IActionResult> CreateAboutWithGoogleGemini()
    {
        var apiKey = "your_api_key";
        var model = "gemini-2.5-flash";
        var url = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";
        var requestBody = new
        {
            contents = new[]
            {
                    new
                    {
                        parts=new[]
                        {
                            new
                            {
                                text="Kurumsal bir sigorta firması için etkileyici, güven verici ve profesyonel bir 'Hakkımızda' yazısı oluştur."
                            }
                        }
                    }
                }
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsync(url, content);
        var responseJson = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(responseJson);
        var aboutText = jsonDoc.RootElement
                             .GetProperty("candidates")[0]
                             .GetProperty("content")
                             .GetProperty("parts")[0]
                             .GetProperty("text")
                             .GetString();

        ViewBag.value = aboutText;

        return View();
    }
}
