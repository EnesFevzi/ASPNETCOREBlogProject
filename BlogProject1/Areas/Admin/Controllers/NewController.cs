using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class NewController : Controller
    {
        protected readonly INewService _newService;
        protected readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<WriterUser> _userManager;
        private readonly IWriterTaskService _writerTaskService;
        protected readonly TContext _context;

        public NewController(INewService newService, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment, 
            UserManager<WriterUser> userManager, IWriterTaskService writerTaskService, TContext context)
        {
            _newService = newService;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _writerTaskService = writerTaskService;
            _context = context;
        }
        [Route("Index")]
        public IActionResult Index()
        {

            var values = _newService.GetNewListWithCategory();
            return View(values);
        }
        [Route("NewsListByWriter")]
        public IActionResult NewsListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = _newService.GetNewsListWithWriter(writerID);
            return View(values);
        }


        [HttpGet]
        [Route("")]
        [Route("AddNew")]
        public IActionResult AddNew()
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
        [Route("")]
        [Route("AddNew")]
        public IActionResult AddNew(New b)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();



            NewValidator validationRules = new NewValidator();
            var results = validationRules.Validate(b);
            if (results.IsValid)
            {
                b.NewStatus = true;
                b.NewsCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterID = writerID;
                _newService.TAdd(b);
                return RedirectToAction("NewsListByWriter", "New");
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



        [Route("")]
        [Route("DeleteNew/{id}")]
        public IActionResult DeleteNew(int id)
        {
            var values = _newService.TGetByID(id);
            _newService.TDelete(values);
            return RedirectToAction("NewsListByWriter", "New");
        }




        [HttpGet]
        [Route("")]
        [Route("EditNew/{id}")]
        public IActionResult EditNew(int id)
        {
            var values = _newService.TGetByID(id);
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
        [Route("")]
        [Route("EditNew/{id}")]
        public IActionResult EditNew(New b)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            b.NewStatus = true;
            b.NewsCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterID = writerID;
            _newService.TUpdate(b);
            return RedirectToAction("NewsListByWriter", "New");
        }
    }
}
