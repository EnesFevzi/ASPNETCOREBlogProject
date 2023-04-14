using ASPNETCOREBlogProject.Areas.Admin.Models;
using ASPNETCOREBlogProject.Models;
using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using NuGet.Packaging.Signing;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]

    public class VideoController : Controller
    {
        protected readonly IVideoService _videoService;
        protected readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<WriterUser> _userManager;
        protected readonly TContext _context;

        public VideoController(IVideoService videoService, TContext context, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment, UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
            _videoService = videoService;
            _context = context;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var values = _videoService.GetVideosListWithCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddVideo()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            AddVideoViewModel w = new AddVideoViewModel
            {
                WriterID = writerID
            };
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVideo(AddVideoViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                //if (model.VideoURL != null)
                //{
                //    var resource = Directory.GetCurrentDirectory();
                //    var extension = Path.GetExtension(model.Video.FileName);
                //    var imagename = Guid.NewGuid() + extension;
                //    var savelocation = resource + "/wwwroot/VideoFiles/" + imagename;
                //    var stream = new FileStream(savelocation, FileMode.Create);
                //    await model.Video.CopyToAsync(stream);

                //}
                if (model.Video != null && model.Video.Length > 0)
                {
                    // Video dosyasını yükleyin ve dosya yolunu güncelleyin
                    var extension = Path.GetExtension(model.Video.FileName);
                    var videoname = Guid.NewGuid() + extension;
                    var savelocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VideoFiles/", videoname);


                    using (var stream = new FileStream(savelocation, FileMode.Create))
                    {
                        await model.Video.CopyToAsync(stream);
                    }

                    model.VideoURL = videoname;
                }

                // Video nesnesini doldurun
                Video video = new Video()
                {

                    VideoTitle = model.VideoTitle,
                    VideoContent = model.VideoContent,
                    VideoURL = model.VideoURL,
                    VideoCreateDate = System.DateTime.Now,
                    WriterID = model.WriterID,
                    VideoStatus = true
                };
                _videoService.TAdd(video);
                return RedirectToAction("Index", "Video");
            }
            var categoryvalues = (from x in _categoryService.TGetList()
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryID.ToString()
                                  }).ToList();
            ViewBag.cv = categoryvalues;
            return View(model);
        }




        public IActionResult DeleteVideo(int id)
        {
            var values = _videoService.TGetByID(id);
            _videoService.TDelete(values);
            return RedirectToAction("Index", "Video");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var values = _videoService.TGetByID(id);
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
        public IActionResult EditVideo(Video b)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.WriterUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            b.VideoStatus = true;
            b.VideoCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterID = writerID;
            _videoService.TUpdate(b);
            return RedirectToAction("Index", "Video");
        }
    }
}
