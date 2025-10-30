using InsureYouAI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class AppUserController(UserManager<AppUser> userManager) : Controller
    {
        public IActionResult UserList()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }

        public async Task<IActionResult> UserProfileWithAI(string id)
        {
            var value = await userManager.FindByIdAsync(id);
            ViewBag.name = value.Name;
            ViewBag.surname = value.Surname;
            ViewBag.imageUrl = value.ImageUrl;
            ViewBag.description = value.Description;
            ViewBag.userTitle = value.Title;
            ViewBag.city = value.City;
            ViewBag.education = value.Education;
            return View();
        }
    }
}
