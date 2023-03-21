using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Repository;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public EfBlogRepository(TContext context) : base(context)
        {

        }

        public List<Blog> GetBlogsListWithCategory()
        {
            return _context.Blogs.Include(b => b.Category).ToList();
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _context.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
        }

        public List<Blog> GetBlogsListWithComments(int id)
        {
            return _context.Blogs.Include(x => x.Comments).Where(x => x.BlogID == id).ToList();
        }

    }

}






