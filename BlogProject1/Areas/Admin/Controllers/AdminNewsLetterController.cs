using BlogProject1.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminNewsLetterController : Controller
    {
        protected readonly INewsLetterService _newsLetterService;

        public AdminNewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        public IActionResult Index()
        {
            var values = _newsLetterService.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _newsLetterService.TGetByID(id);
            _newsLetterService.TDelete(values);
            return RedirectToAction("Index", "AdminNewsLetter");
        }

        public IActionResult ContactDetails(int id)
        {
            var values = _newsLetterService.TGetByID(id);
            return View(values);
        }
    }
}
