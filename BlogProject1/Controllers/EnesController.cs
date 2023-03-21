using Microsoft.AspNetCore.Mvc;

namespace BlogProject1BlogProject.Controllers
{
    public class EnesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
