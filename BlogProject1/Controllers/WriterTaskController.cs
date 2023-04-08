using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCOREBlogProject.Controllers
{
    public class WriterTaskController : Controller
    {
        private readonly IWriterTaskService _writerTaskService;
        private readonly UserManager<WriterUser> _userManager;
        private readonly TContext _context;

        public WriterTaskController(IWriterTaskService writerTaskService, UserManager<WriterUser> userManager, TContext context)
        {
            _writerTaskService = writerTaskService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var writerTasks = _context.WriterTasks.Where(x => x.WriterID == writerID).ToList();
            var values = _writerTaskService.GetWriterTaskList(writerID);
            return View(writerTasks);
        }

        public IActionResult AddWriterTask(WriterTask writerTask)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();



            WriterTaskValidator validationRules = new WriterTaskValidator();
            var results = validationRules.Validate(writerTask);
            if (results.IsValid)
            {
                writerTask.WriterID = writerID;
                writerTask.IsApproved = true;
                writerTask.TaskCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _writerTaskService.TAdd(writerTask);
                return RedirectToAction("Index", "WriterTask");
                // Görev kaydetme işlemini gerçekleştirin  
            }
            else
            {
                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                // Doğrulama hatası olduğu için hata mesajlarını döndürün          
            }
            return View(writerTask);

        }

        public IActionResult DeleteWriterTask(int id)
        {
            var values = _writerTaskService.TGetByID(id);
            _writerTaskService.TDelete(values);
            return RedirectToAction("Index", "WriterTask");
        }
        [HttpGet]
        public IActionResult EditWriterTask(int id)
        {
            var values = _writerTaskService.TGetByID(id);
            //List<SelectListItem> categoryvalues = (from x in _categoryManager.TGetList()
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryID.ToString()

            //                                       }).ToList();
            //ViewBag.cv = categoryvalues;

            return View(values);
        }
        [HttpPost]
        public IActionResult EditWriterTask(WriterTask writerTask)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            writerTask.WriterID = writerID;
            writerTask.IsCompleted = true;
            writerTask.TaskCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _writerTaskService.TUpdate(writerTask);
            return RedirectToAction("Index", "WriterTask");
        }
    }
}
