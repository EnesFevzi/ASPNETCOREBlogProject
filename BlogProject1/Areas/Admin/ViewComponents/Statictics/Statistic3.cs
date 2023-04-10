using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.Statictics
{
    public class Statistic3 : ViewComponent
    {
        private readonly TContext _context;
        private readonly UserManager<WriterUser> _userManager;

        public Statistic3(TContext context, UserManager<WriterUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = value.Name;
            ViewBag.v4 = value.Surname;
            ViewBag.v2 = value.ImageUrl;
            //ViewBag.v3 = value.About;
            //ViewBag.v1 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.Name);
            //ViewBag.v2 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            //ViewBag.v3 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
