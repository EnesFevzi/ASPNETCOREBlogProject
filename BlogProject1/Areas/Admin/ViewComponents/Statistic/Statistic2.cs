using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.Statictics
{
    public class Statistic2 : ViewComponent
    {
        private readonly TContext _context;
        private readonly IBlogService _blogService;

        public Statistic2(TContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _blogService.TGetList();
            ViewBag.v1 = value.Select(y => y.BlogTitle).TakeLast(1).FirstOrDefault();
            //ViewBag.v2 = _blogService.GetCountAsync(x => x.BlogStatus);
            ViewBag.v2 = _context.Blogs.Count();
            return View();
        }
    }
}
