using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultMobileMenuComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.email = context.Contacts.Select(x => x.Email).FirstOrDefault();
        ViewBag.phone = context.Contacts.Select(x => x.Phone).FirstOrDefault();
        return View();
    }
}
