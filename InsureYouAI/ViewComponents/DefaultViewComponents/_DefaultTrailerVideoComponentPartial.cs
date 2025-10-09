using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultTrailerVideoComponentPartial(InsureContext context): ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.TrailerVideos.ToList();
        return View(values);
    }
}
