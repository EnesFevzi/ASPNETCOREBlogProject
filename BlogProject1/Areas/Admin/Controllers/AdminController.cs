using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    
    public class AdminController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;
        private readonly TContext _context;

        public AdminController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager, TContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult AdminNavbarPartial()

        {
            var usermail = User.Identity.Name;
            ViewBag.mailName = usermail;
            var writerName = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Name).FirstOrDefault();
            ViewBag.writerName = writerName;
            return PartialView();
        }
    }
}
