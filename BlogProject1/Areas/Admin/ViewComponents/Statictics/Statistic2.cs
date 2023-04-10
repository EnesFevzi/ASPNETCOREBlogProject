using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.Statictics
{
    public class Statistic2 : ViewComponent
    {
        private readonly TContext _context;

        public Statistic2(TContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = _context.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = _context.Comments.Count();
            return View();
        }
    }
}
