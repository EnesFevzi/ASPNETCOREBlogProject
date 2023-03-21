using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class FeatureStatistics:ViewComponent
    {

        protected readonly TContext _context;
        public FeatureStatistics(TContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.ToplamBlogSayisi = _context.Blogs.Count(x => x.BlogStatus == true);
            ViewBag.YazarinBlogSayisi = _context.Blogs.Count(x => x.WriterID == 1);
            ViewBag.KategoriSayisi = _context.Categories.Count(x => x.CategoryStatus == true);
            return View();
        }
    }
}
