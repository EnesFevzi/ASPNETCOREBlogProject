using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BlogProject1.EntityLayer.Concrete;

namespace ASPNETCOREBlogProject.Controllers
{
    [Authorize(Roles = "Writer")]
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository(new TContext()));

        private readonly UserManager<WriterUser> _userManager;
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly TContext _context;
        public DashboardController(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager, TContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Values = values.Name + " " + values.Surname;
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //ViewBag.v1 = c.Blogs.Count().ToString();
            //ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count();
            //ViewBag.v3 = c.Categories.Count();
            //ViewBag.v4 = "Enes";
            ViewBag.v1 = _context.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.v3 = _context.Users.Count();
            ViewBag.v4 = _context.Categories.Count();
            return View();
        }

        public async Task<PartialViewResult> SideBarAbove()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Values = values.Name + " " + values.Surname;
            return PartialView();
        }
    }
}
