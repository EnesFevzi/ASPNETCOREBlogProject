using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BlogProject1.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using BlogProject1.EntityLayer.Concrete;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        protected readonly IWriterMessageService _message2Manager;
        private readonly UserManager<WriterUser> _userManager;
        protected readonly TContext _context;

        public WriterMessageNotification(IWriterMessageService message2Manager, UserManager<WriterUser> userManager, TContext context)
        {
            _message2Manager = message2Manager;
            _userManager = userManager;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _message2Manager.TGetList();
            return View(values);

        }
    }
}
