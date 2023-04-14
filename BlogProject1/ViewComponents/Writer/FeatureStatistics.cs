using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class FeatureStatistics:ViewComponent
    {

        private readonly UserManager<WriterUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;
        private readonly IWriterMessageService _writerMessageService;
        private readonly TContext _context;

        public FeatureStatistics(UserManager<WriterUser> userManager, IBlogService blogService, 
            IMessageService messageService, ICommentService commentService, IWriterMessageService writerMessageService, TContext context)
        {
            _userManager = userManager;
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
            //ViewBag.NotificationCount = await _notificationService.GetCountAsync();
            ViewBag.SendedMessageCount = await _writerMessageService.GetCountAsync(x => x.SenderName == value.Name);
            ViewBag.ToplamBlogSayisi = await _blogService.GetCountAsync();
            ViewBag.YazarinBlogSayisi = await _blogService.GetCountAsync(x => x.WriterID == value.Id);
            ViewBag.KategoriSayisi = _context.Categories.Count(x => x.CategoryStatus == true);
            return View();
        }
    }
}
