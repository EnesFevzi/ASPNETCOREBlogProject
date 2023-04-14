using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    public class NewController : Controller
    {
        protected readonly INewService _newService;
        protected readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<WriterUser> _userManager;
        private readonly IWriterTaskService _writerTaskService;
        protected readonly TContext _context;

        public NewController(INewService newService, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment,
            UserManager<WriterUser> userManager, IWriterTaskService writerTaskService, TContext context)
        {
            _newService = newService;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _writerTaskService = writerTaskService;
            _context = context;
        }
        public IActionResult Index()
        {

            var values = _newService.GetNewListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult VideoDetails(int id)
        {
            @ViewBag.i = id;
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _newService.GetNewByID(id);
            return View(values);
        }
        public IActionResult VideoListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _newService.GetNewsListWithWriter(writerID);
            return View();
        }
    }
}
