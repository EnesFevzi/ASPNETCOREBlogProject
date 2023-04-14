using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class VideoController : Controller
    {
        protected readonly IVideoService _videoService;
        protected readonly ICategoryService _categoryService;
        protected readonly TContext _context;

        public VideoController(IVideoService videoService, TContext context, ICategoryService categoryService)
        {
            _videoService = videoService;
            _context = context;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _videoService.GetVideosListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult VideoDetails(int id)
        {
            @ViewBag.i = id;
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _videoService.GetVideoByID(id);
            return View(values);
        }
        public IActionResult VideoListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _videoService.GetVideosListWithWriter(writerID);
            return View();
        }
        
    }
}
