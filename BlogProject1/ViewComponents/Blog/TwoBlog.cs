using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
    public class TwoBlog : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly TContext _context;
        public TwoBlog(IBlogService blogService, TContext context)
        {
            _blogService = blogService;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastTwoBlogs = await _context.Blogs
                .OrderByDescending(b => b.BlogID)
                .Take(2)
                .ToListAsync();

            return View(lastTwoBlogs);
        }
    }
}
