using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]

    public class GeneralAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public GeneralAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }
        [HttpGet]

        public IActionResult AddGeneralAbout()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddGeneralAbout(About about)
        {
            about.AboutStatus = true;
            _aboutService.TAdd(about);
            return RedirectToAction("Index", "CancerAbout", new { area = "Admin" });

        }
        public IActionResult GeneralAboutDelete(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return RedirectToAction("Index", "GeneralAbout", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditGeneralAbout(int id)
        {
            var category = _aboutService.TGetByID(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditGeneralAbout(About about)
        {
            _aboutService.TUpdate(about);
            return RedirectToAction("Index", "GeneralAbout");
        }
    }
}
