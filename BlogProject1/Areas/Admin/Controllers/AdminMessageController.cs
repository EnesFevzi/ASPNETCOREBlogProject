using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IWriterMessageService _writermessageService;
        private readonly UserManager<WriterUser> _userManager;
        private readonly TContext _context;

        public AdminMessageController(IWriterMessageService writermessageService, UserManager<WriterUser> userManager, TContext context)
        {
            _writermessageService = writermessageService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> InBox(string p)

        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writermessageService.GetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> SendBox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writermessageService.GetListSenderMessage(p);
            return View(messageList);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ComposeMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            var usernamesurname = _context.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writermessageService.TAdd(p);

            return RedirectToAction("InBox");
        }
    }
}
