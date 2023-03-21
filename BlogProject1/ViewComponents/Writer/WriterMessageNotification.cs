using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        protected readonly WriterMessageManager _message2Manager;
        protected readonly TContext _context;

        public WriterMessageNotification(WriterMessageManager message2Manager, TContext context)
        {
            _message2Manager = message2Manager;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
