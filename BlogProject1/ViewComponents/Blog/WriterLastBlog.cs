using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository(new TContext()));
        public IViewComponentResult Invoke(int id)
        {
            var blogs = bm.GetBlogsListWithWriter(id);
            return View();
        }
    }
}
