using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace ASPNETCOREBlogProject.ViewComponents.Comment
{
    public class CommentList:ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository(new TContext()));
        BlogManager _blogManager = new BlogManager(new EfBlogRepository(new TContext()));
        
        protected readonly UserManager<WriterUser> _userManager;
        protected readonly TContext _context;
        public CommentList(UserManager<WriterUser> userManager, TContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var comments = _commentManager.TGetList(id);
            return View(comments);
        }


    }

}
