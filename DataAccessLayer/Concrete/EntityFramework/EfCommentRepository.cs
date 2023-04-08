using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Repository;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Concrete.EntityFramework
{
	public class EfCommentRepository : GenericRepository<Comment>,ICommentRepository
	{
		public EfCommentRepository(TContext context) : base(context)
		{
		}
        public List<Blog> GetCommentsByBlog(int id)
        {
            return _context.Blogs.Include(x => x.Comments).Where(x => x.BlogID == id).ToList();
        }

        public List<Comment> GetListWithBlog()
        {
           return _context.Comments.Include(x => x.Blog).ToList();
        }
    }
}
