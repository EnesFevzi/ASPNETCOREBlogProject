using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

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



        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var value = await _userManager.FindByNameAsync(User.Identity.Name);
        //    ViewBag.v1 = value.Name;
        //    ViewBag.v2 = value.Surname;
        //    ViewBag.v3 = value.ImageUrl;
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.UserCount = await _userService.GetByUserCountAsync();
            //ViewBag.LikeCommentCount = await _commentService.GetCountAsync(x => x.BlogScore > 2);
            ViewBag.NewsLetterCount = await _newsLetterService.GetCountAsync();
            //ViewBag.CategoryCount = await _categoryService.GetCountAsync();
            string exchangeRate = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(exchangeRate);
                ViewBag.Euro = xmlDoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml.ToString();
                ViewBag.Dolar = xmlDoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml.ToString();
            }
            catch
            {

                ViewBag.Euro = 0;
                ViewBag.Dolar = 0;
            }
            return View();
        }
    }
}
