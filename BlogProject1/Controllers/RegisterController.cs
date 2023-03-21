using ASPNETCOREBlogProject.Models;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly SignInManager<WriterUser> _signInManager;

        public RegisterController(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            WriterUser appUser = new WriterUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                ImageUrl = p.ImageUrl
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
