using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    public class AdminContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
