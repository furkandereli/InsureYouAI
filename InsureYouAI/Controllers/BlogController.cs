using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
    public async Task<IActionResult> AddComment(Comment comment)
    {
        comment.CommentDate = DateTime.Now;
        comment.AppUserId = "81bcb310-3fde-414a-85db-ec81d7af1c2b";

        using (var client = new HttpClient())
        {
            var apiKey = "your_api_key";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var translateRequestBody = new
                {
                    inputs = comment.CommentDetail
                };

                var translateJson = JsonSerializer.Serialize(translateRequestBody);
                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

                var translateResponse = await client.PostAsync("https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
                var translateResponseString = await translateResponse.Content.ReadAsStringAsync();

                string englishText = comment.CommentDetail;
                if (translateResponseString.TrimStart().StartsWith("["))
                {
                    var translateDoc = JsonDocument.Parse(translateResponseString);
                    englishText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
                }

                var toxicRequestBody = new
                {
                    inputs = englishText
                };

                var toxicJson = JsonSerializer.Serialize(toxicRequestBody);
                var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
                var toxicResponse = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);
                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();

                if (toxicResponseString.TrimStart().StartsWith("["))
                {
                    var toxicDoc = JsonDocument.Parse(toxicResponseString);
                    foreach (var item in toxicDoc.RootElement[0].EnumerateArray())
                    {
                        string label = item.GetProperty("label").GetString();
                        double score = item.GetProperty("score").GetDouble();

                        if (score > 0.5)
                        {
                            comment.CommentStatus = "Toksik Yorum";
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(comment.CommentStatus))
                {
                    comment.CommentStatus = "Yorum Onaylandı";
                }
            }
            catch (Exception ex)
            {
                comment.CommentStatus = "Onay Bekliyor";
            }
        }

        context.Comments.Add(comment);
        context.SaveChanges();
        return RedirectToAction("BlogList");
    }
}
