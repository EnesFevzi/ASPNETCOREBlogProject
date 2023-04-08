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
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (userRegisterViewModel.Picture != null)
            {
                var extension = Path.GetExtension(userRegisterViewModel.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await userRegisterViewModel.Picture.CopyToAsync(stream);
                }
                userRegisterViewModel.PictureURL = imagename;
            }

            WriterUser appUser = new WriterUser()
            {
                Name = userRegisterViewModel.PictureURL,
                Surname = userRegisterViewModel.PictureURL,
                Email = userRegisterViewModel.PictureURL,
                UserName = userRegisterViewModel.PictureURL,
                ImageUrl = userRegisterViewModel.PictureURL
            };

            if (userRegisterViewModel.PictureURL == userRegisterViewModel.PictureURL)
            {
                var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.PictureURL);

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
            return View(userRegisterViewModel);
        }
    }
}
