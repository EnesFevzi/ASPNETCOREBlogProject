using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
	public class AboutController : Controller
	{
		//AboutManager aboutManager= new AboutManager(new EfAboutRepository(new TContext()))
		private readonly IAboutService _aboutService;
		private readonly ICancerAboutService _cancerAboutService;

        public AboutController(IAboutService aboutService, ICancerAboutService cancerAboutService)
        {
            _aboutService = aboutService;
            _cancerAboutService = cancerAboutService;
        }

        public IActionResult Index()

		{
            var values = _aboutService.TGetList();
            return View(values);
        }

		public PartialViewResult SocaialMediaAbout()
		{
			return PartialView();
		}

	}
}
