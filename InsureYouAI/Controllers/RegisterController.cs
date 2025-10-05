using InsureYouAI.Context;
using InsureYouAI.DTOs.Register;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class RegisterController(UserManager<AppUser> userManager) : Controller
    {
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRegisterDTO createUser)
        {
            AppUser appUser = new()
            {
                Name = createUser.Name,
                Surname = createUser.Surname,
                Email = createUser.Email,
                UserName = createUser.Username,
                ImageUrl = "Test",
                Description = "Açıklama"
            };

            await userManager.CreateAsync(appUser, createUser.Password);
            return RedirectToAction("UserList");
        }
    }
}
