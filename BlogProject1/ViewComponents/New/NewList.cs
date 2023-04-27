using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.ViewComponents.New
{
	public class NewList : ViewComponent
	{
		private readonly INewService _newService;
		private readonly TContext _context;
		public NewList(INewService newService, TContext context)
		{
			_newService = newService;
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var lastThreeNews = await _context.News
				.OrderByDescending(b => b.NewID)
				.Take(2).
				ToListAsync();

			return View(lastThreeNews);
		}
	}

}
