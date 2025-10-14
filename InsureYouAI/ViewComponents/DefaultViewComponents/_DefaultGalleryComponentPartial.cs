using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultGalleryComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var values = context.Galleries.ToList();
        return View(values);
    }
}
