using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
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
        readonly INewsLetterService _newsLetterService;
        readonly ICommentService _commentService;
        readonly ICategoryService _categoryService;
        private readonly IWriterUserService _userService;

        public Statistic3(TContext context, UserManager<WriterUser> userManager, INewsLetterService newsLetterService, ICommentService commentService, ICategoryService categoryService, IWriterUserService userService)
        {
            _context = context;
            _userManager = userManager;
            _newsLetterService = newsLetterService;
            _commentService = commentService;
            _categoryService = categoryService;
            _userService = userService;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    ViewBag.UserCount = await _userService.GetByUserCountAsync();
        //    ViewBag.LikeCommentCount = await _commentService.GetCountAsync(x => x.BlogScore > 2);
        //    ViewBag.NewsLetterCount = await _newsLetterService.GetCountAsync();
        //    ViewBag.CategoryCount = await _categoryService.GetCountAsync();
        //    return View();
        //}



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = value.Name;
            ViewBag.v2 = value.Surname;
            ViewBag.v3 = value.ImageUrl;
            //ViewBag.v3 = value.About;
            //ViewBag.v1 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.Name);
            //ViewBag.v2 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            //ViewBag.v3 = _context.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
