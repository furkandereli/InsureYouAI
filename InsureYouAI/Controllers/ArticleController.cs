using InsureYouAI.Context;
using InsureYouAI.DTOs.OpenAI;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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

    [HttpGet]
    public IActionResult CreateArticleWithOpenAI()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticleWithOpenAI(string prompt)
    {
        var apikey = "your_chatgpt_key";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);

        var requestData = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Sen bir sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın. Kullanıcının verdiği özet ve anahtar kelimelere göre, sigortacılık seötkrüyle ilgili makale üret. En az bin karakter olsun." },
                new { role = "user", content = prompt}
            },
            temperature = 0.7
        };

        var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            var content = result.choices[0].message.content;
            ViewBag.article = content;
        }
        else
        {
            ViewBag.article = "Error: " + response.StatusCode;
        }

        return View();
    }
}
