﻿using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        //BlogManager _blogManager = new BlogManager(new EfBlogRepository(new TContext()));
        //CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository(new TContext()));
        //CommentManager _commentManager = new CommentManager(new EfCommentRepository(new TContext()));
        protected readonly IBlogService _blogService;
        protected readonly ICategoryService _categoryService;
        protected readonly ICommentService _commentService;
        protected readonly TContext _context;

        public BlogController(IBlogService blogService, ICategoryService categoryService, ICommentService commentService, TContext context)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _commentService = commentService;
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetBlogsListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            @ViewBag.i=id;
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _blogService.GetBlogByID(id);
            return View(values);
        }


        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _blogService.GetBlogsListWithWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();



            BlogValidator validationRules = new BlogValidator();
            var results = validationRules.Validate(b);
            if (results.IsValid)
            {
                b.BlogStatus = true;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterID = writerID;
                _blogService.TAdd(b);
                return RedirectToAction("BlogListByWriter", "Blog");
                // Blog kaydetme işlemini gerçekleştirin  
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                // Doğrulama hatası olduğu için hata mesajlarını döndürün          
            }
            return View();

        }

        public IActionResult DeleteBlog(int id)
        {
            var values = _blogService.TGetByID(id);
            _blogService.TDelete(values);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var values = _blogService.TGetByID(id);
            List<SelectListItem> categoryvalues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View(values);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            b.BlogStatus = true;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterID = writerID;
            _blogService.TUpdate(b);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
