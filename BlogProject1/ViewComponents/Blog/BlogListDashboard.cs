using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository(new TContext()));

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogsListWithCategory();
            return View(values);
        }
    }
}
