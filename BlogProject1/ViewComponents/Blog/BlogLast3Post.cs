using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository(new TContext()));
		public IViewComponentResult Invoke()
		{
			var blogs = bm.TGetList();
			return View();
		}
	}
}
