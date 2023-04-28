using BlogProject1.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        protected readonly IBlogService _blogService;

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
        public PartialViewResult CancerBlog()
        {
            return PartialView();
        }
        public PartialViewResult CancerBlog2()
        {
            return PartialView();
        }
    }
}
