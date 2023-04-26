using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASPNETCOREBlogProject.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly TContext _context;

        public WriterLastBlog(IBlogService blogService, TContext context)
        {
            _blogService = blogService;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastThreeBlogs = await _context.Blogs
                .OrderByDescending(b => b.BlogID)
                .Take(3)
                .ToListAsync();

            return View(lastThreeBlogs);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int writerId, int blogId)
        //{
        //    var blogs = await _blogService.GetBlogListByWriterAsync(writerId);
        //    var values = blogs.Where(x => x.BlogStatus).ToList();
        //    var currentBlog = values.FirstOrDefault(x => x.BlogID == blogId);
        //    values.Remove(currentBlog);
        //    return View(values.TakeLast(4).ToList());
        //}

        //public async Task<IViewComponentResult> InvokeAsync(int writerId)
        //{
        //    // Yazarın son 3 blogunu veritabanından çekme
        //    var blogs = await _context.Blogs
        //        .Where(b => b.WriterID == writerId)
        //        .OrderByDescending(b => b.BlogCreateDate)
        //        .Take(3)
        //        .ToListAsync();

        //    return View(blogs);
        //}





    }
}
