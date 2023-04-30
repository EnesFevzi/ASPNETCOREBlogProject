using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class CancerAboutController : Controller
    {
        private readonly ICancerAboutService _cancerAboutService;

        public CancerAboutController(ICancerAboutService cancerAboutService)
        {
            _cancerAboutService = cancerAboutService;
        }

        public IActionResult Index()
        {
            var values = _cancerAboutService.TGetList();
            return View(values);
        }
        [HttpGet]

        public IActionResult AddCancerAbout()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddCancerAbout(CancerAbout cancerAbout)
        {
            cancerAbout.CancerAboutStatus = true;
            _cancerAboutService.TAdd(cancerAbout);
            return RedirectToAction("Index", "CancerAbout", new { area = "Admin" });

        }
        public IActionResult CancerAboutDelete(int id)
        {
            var value = _cancerAboutService.TGetByID(id);
            _cancerAboutService.TDelete(value);
            return RedirectToAction("Index", "CancerAbout", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditCancerAbout(int id)
        {
            var category = _cancerAboutService.TGetByID(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCancerAbout(CancerAbout cancerAbout)
        {
            _cancerAboutService.TUpdate(cancerAbout);
            return RedirectToAction("Index", "CancerAbout");
        }
    }
}
