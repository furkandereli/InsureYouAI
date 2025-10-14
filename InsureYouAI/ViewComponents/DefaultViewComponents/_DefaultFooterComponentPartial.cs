using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultFooterComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.description = context.Contacts.Select(x => x.Description).FirstOrDefault();
        ViewBag.phone = context.Contacts.Select(x => x.Phone).FirstOrDefault();
        ViewBag.email = context.Contacts.Select(x => x.Email).FirstOrDefault();
        ViewBag.address = context.Contacts.Select(x => x.Address).FirstOrDefault();
        return View();
    }
}
