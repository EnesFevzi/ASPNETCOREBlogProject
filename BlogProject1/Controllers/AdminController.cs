using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
