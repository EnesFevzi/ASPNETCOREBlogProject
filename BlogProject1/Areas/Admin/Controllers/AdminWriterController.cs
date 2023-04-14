using ASPNETCOREBlogProject.Areas.Admin.Models;
using ASPNETCOREBlogProject.Models;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminWriterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly TContext _context;

        public AdminWriterController(UserManager<WriterUser> userManager, TContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
