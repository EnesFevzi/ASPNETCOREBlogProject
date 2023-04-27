using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
	public class WriterLastNew : ViewComponent
	{
		private readonly INewService _newService;
		private readonly TContext _context;

		public WriterLastNew(INewService newService, TContext context)
		{
			_newService = newService;
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var lastThreeNews = await _context.News
				.OrderByDescending(b => b.NewID)
				.Take(3)
				.ToListAsync();

			return View(lastThreeNews);
		}
	}
}
