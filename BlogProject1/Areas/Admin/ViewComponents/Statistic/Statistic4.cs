using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.Statictics
{
    public class Statistic4:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly IContactService _contactService;
        private readonly INotificationService _notificationService;
        private readonly IBlogService _blogService;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;

        public Statistic4(UserManager<WriterUser> userManager, IContactService contactService, 
            INotificationService notificationService, IBlogService blogService,
            IMessageService messageService, ICommentService commentService)
        {
            _userManager = userManager;
            _contactService = contactService;
            _notificationService = notificationService;
            _blogService = blogService;
            _messageService = messageService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = value.Name;
            ViewBag.v7 = value.Surname;
            ViewBag.v2 = value.ImageUrl;
            ViewBag.v4 = value.Email;
            ViewBag.BlogCount = await _blogService.GetCountAsync(x => x.WriterID == value.Id);

            return View();
        }
    }
}
