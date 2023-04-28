using BlogProject1.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    public class CancerAboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ICancerAboutService _cancerAboutService;

        public CancerAboutController(IAboutService aboutService, ICancerAboutService cancerAboutService)
        {
            _aboutService = aboutService;
            _cancerAboutService = cancerAboutService;
        }
        public IActionResult Index()
        {
            var values= _cancerAboutService.TGetList();
            return View(values);
        }
    }
}
