using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.WriterNavbarProfile
{
    public class AdminWriterNavbarProfile:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly SignInManager<WriterUser> _signInManager;

        public AdminWriterNavbarProfile(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Names = writer.Name + " " + writer.Surname;
            ViewBag.Values = writer.ImageUrl;
            var roles = await _userManager.GetRolesAsync(writer);
            ViewBag.Role = roles.FirstOrDefault();
            return View(writer);
        }
    }
}
