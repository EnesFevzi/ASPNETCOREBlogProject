using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace ASPNETCOREBlogProject.Controllers
{
    public class MessageController : Controller
    {
        WriterMessageManager _writermessageManager = new WriterMessageManager(new EfWriterMessageRepository(new TContext()));
        protected readonly TContext _context;
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(TContext context, UserManager<WriterUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> InBox(string p)

        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writermessageManager.GetListReceiverMessage(p);
            return View(messageList);



            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var values = _writermessageManager.GetInboxListByWriter(writerID);
            //return View(values);

        }
        public async Task<IActionResult> SendBox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writermessageManager.GetListSenderMessage(p);
            return View(messageList);


            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var values = _writermessageManager.GetSendBoxListByWriter(writerID);
            //return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = _writermessageManager.TGetByID(id);
            return View(values);
        }
        [HttpGet]

        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = _writermessageManager.TGetByID(id);
            return View(writerMessage);

        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            var usernamesurname = _context.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writermessageManager.TAdd(p);

            return RedirectToAction("InBox");


            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //string mail = values.Email;
            //string name = values.Name + " " + values.Surname;
            //int senderId = values.Id;
            //p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //p.SenderUserId = senderId;
            //p.MessageStatus = true;
            //var receiverID = _context.Users.Where(x => x.Email == ReceiverUser).Select(y => y.Id).FirstOrDefault();

            //_writermessageManager.TAdd(p);
            //return RedirectToAction("InBox");
            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var senderID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var receiverMail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault(); // Kullanıcının formda yazdığı email adresi
            //var receiverID = _context.Users.Where(x => x.Email == receiverMail).Select(y => y.Id).FirstOrDefault();
            //p.ReceiverUserId = receiverID;
            //p.SenderUserId = senderID;
            //p.MessageStatus = true;
            //p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //_writermessageManager.TAdd(p);
            //return RedirectToAction("InBox");







































            //var senderUsername = User.Identity.Name;
            //var senderUser = await _userManager.FindByNameAsync(senderUsername);
            //var receiverUser = await _userManager.FindByNameAsync(receiverEmail);
            //var writerID = senderUser.Id;
            //var receiverID = receiverUser.Id;

            //p.SenderUserId = writerID;
            //p.ReceiverUserId = receiverID;
            //p.MessageStatus = true;
            //p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            //_writermessageManager.TAdd(p);
            //return RedirectToAction("InBox");
























            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //p.SenderUserId = writerID;
            //p.ReceiverUserId = 5;
            //p.MessageStatus = true;
            //p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //_writermessageManager.TAdd(p);
            //return RedirectToAction("InBox");


            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var senderID = _context.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var receiverID = _context.Users.Where(x => x.Id == p.ReceiverUserId).Select(y => y.Id).FirstOrDefault();
            //p.SenderUserId = writerID;
            //p.WriterSender = _context.Users.FirstOrDefault(x => x.Id == senderID);
            //p.ReceiverUserId = receiverID;
            //p.WriterReceiver = _context.Users.FirstOrDefault(x => x.Id == receiverID);
            //p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.MessageStatus = true;
            //_writermessageManager.TAdd(p);
            //return RedirectToAction("InBox");

        }


    }
}

