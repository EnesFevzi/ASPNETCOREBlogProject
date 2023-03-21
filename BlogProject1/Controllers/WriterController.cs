using ASPNETCOREBlogProject.Models;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IO;
using System.Threading.Tasks;

namespace ASPNETCOREBlogProject.Controllers
{
    public class WriterController : Controller
    {
        WriterUserManager writerManager = new WriterUserManager(new EfWriterUserRepository(new TContext()));

        private readonly UserManager<WriterUser> _userManager;
        private readonly TContext _context;

        public WriterController(UserManager<WriterUser> userManager, TContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [Authorize(Roles = "Writer")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Writer")]
        public PartialViewResult WriterNavbarPartial()
        {
            var usermail = User.Identity.Name;
            ViewBag.mailName = usermail;
            var writerName = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Name).FirstOrDefault();
            ViewBag.writerName = writerName;
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [Authorize(Roles="Writer")]
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageUrl;


            string userName = !string.IsNullOrEmpty(values.Name) ? values.Name : User.Identity.Name;
            values = await _userManager.FindByNameAsync(userName);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userEditViewModel.Picture != null)
            {
                var extension = Path.GetExtension(userEditViewModel.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await userEditViewModel.Picture.CopyToAsync(stream);
                }
                user.ImageUrl = imagename;
            }

            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("WriterEditProfile", "Writer");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userEditViewModel);
        }

    }
}
