using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardWidgetsComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        int n1, n2, n3, n4;
        int r1, r2, r3, r4;
        Random random = new Random();
        r1 = random.Next(0, 10);
        n1 = random.Next(1, 30);

        r2 = random.Next(0, 10);
        n2 = random.Next(1, 30);

        r3 = random.Next(0, 10);
        n3 = random.Next(1, 30);

        r4 = random.Next(0, 10);
        n4 = random.Next(1, 30);

        ViewBag.v1 = context.Articles.Count();
        ViewBag.v2 = context.Categories.Count();
        ViewBag.v3 = context.Comments.Count();
        ViewBag.v4 = context.Users.Count();

        ViewBag.r1 = n1 + "." + r1;
        ViewBag.r2 = n2 + "." + r2;
        ViewBag.r3 = n3 + "." + r3;
        ViewBag.r4 = n4 + "." + r4;

        return View();
    }
}
