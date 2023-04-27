using BlogProject1.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        private readonly IBlogService _blogService;

        public HomePageController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }
		public PartialViewResult Banner()
		{
			return PartialView();
		} 
    }
}
