using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using BlogProject1.BusinessLayer.Abstract;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly IContactService _contactService;
        private readonly INotificationService _notificationService;
        private readonly IBlogService _blogService;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;
        private readonly IWriterMessageService _writerMessageService;
        private readonly TContext _context;

        public WriterAboutOnDashboard(UserManager<WriterUser> userManager, IContactService contactService, INotificationService notificationService, IBlogService blogService, 
            IMessageService messageService, ICommentService commentService, IWriterMessageService writerMessageService, TContext context)
        {
            _userManager = userManager;
            _contactService = contactService;
            _notificationService = notificationService;
            _blogService = blogService;
            _messageService = messageService;
            _commentService = commentService;
            _writerMessageService = writerMessageService;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = value.Name;
            ViewBag.v2 = value.Surname;
            ViewBag.v3 = value.ImageUrl;
            ViewBag.v4 = value.Email;
            return View(value);
        }

    }
}
