using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BlogProject1.BusinessLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
	public class BlogList : ViewComponent
	{
		private readonly IBlogService _blogService;
		private readonly TContext _context;
		public BlogList(IBlogService blogService, TContext context)
		{
			_blogService = blogService;
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var lastThreeBlogs = await _context.Blogs
				.OrderByDescending(b => b.BlogID)
				.Take(2)
				.ToListAsync();

			return View(lastThreeBlogs);
		}
	}

}
