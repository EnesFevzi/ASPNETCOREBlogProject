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
        public DashboardController(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Values = values.Name + " " + values.Surname;
            //TContext c = new TContext();
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerid = c.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //ViewBag.v1 = c.Blogs.Count().ToString();
            //ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count();
            //ViewBag.v3 = c.Categories.Count();
            //ViewBag.v4 = "Enes";
            TContext context = new TContext();
            ViewBag.v1 = context.Message2s.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 = context.Categories.Count();
            return View();
        }
    }
}
