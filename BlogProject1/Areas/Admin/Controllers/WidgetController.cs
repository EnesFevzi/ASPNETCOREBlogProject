using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
