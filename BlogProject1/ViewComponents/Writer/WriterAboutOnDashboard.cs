using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        protected readonly WriterUserManager _writerManager;
        protected readonly TContext _context;

        public WriterAboutOnDashboard(WriterUserManager writerManager, TContext context)
        {
            _writerManager = writerManager;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _writerManager.GetWriterByID(writerID);
            return View(values);
        }

    }
}
