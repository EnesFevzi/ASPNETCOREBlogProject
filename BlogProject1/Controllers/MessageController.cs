﻿using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //var username = User.Identity.Name;
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var messagelist = _writermessageManager.GetListReceiverMessage(p);
            return View(values);

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
            //var values = _message2Manager.GetSendBoxListByWriter(writerID);
            //return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = _writermessageManager.TGetByID(id);
            return View(values);
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
            //var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //p.SenderId = writerID;
            //p.ReceiverId = 5;
            //p.MessageStatus = true;
            //p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            TContext c = new TContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writermessageManager.TAdd(p);
            return RedirectToAction("InBox");
        }
    }
}

