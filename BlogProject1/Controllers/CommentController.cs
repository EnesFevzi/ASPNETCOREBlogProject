using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager =new CommentManager(new EfCommentRepository(new TContext()));
       BlogManager blogManager =new BlogManager(new EfBlogRepository(new TContext()));
        protected readonly TContext _context;

        public CommentController(TContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
 
        [HttpGet]
        public PartialViewResult PartialAddComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {

            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            commentManager.TAdd(p);
            return RedirectToAction("BlogListByWriter", "Blog");
        }


    }
}
