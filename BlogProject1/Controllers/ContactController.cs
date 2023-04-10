using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository(new TContext()));


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            contactManager.TAdd(contact);
            return RedirectToAction("Index", "Contact");
        }
    }
}
