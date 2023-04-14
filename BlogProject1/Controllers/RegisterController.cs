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

            WriterUser appUser = new WriterUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Mail,
                UserName = userRegisterViewModel.UserName,
                ImageUrl = userRegisterViewModel.ImageUrl,
            };

            if (userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (userRegisterViewModel.Picture != null)
                    {
                        var resource = Directory.GetCurrentDirectory();
                        var extension = Path.GetExtension(userRegisterViewModel.Picture.FileName);
                        var imagename = Guid.NewGuid() + extension;
                        var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                        var stream = new FileStream(savelocation, FileMode.Create);
                        await userRegisterViewModel.Picture.CopyToAsync(stream);
                        user.ImageUrl = imagename;
                        await _userManager.UpdateAsync(appUser); // Güncellenen satır
                    }

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
