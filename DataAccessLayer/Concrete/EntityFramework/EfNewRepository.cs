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
    public class EfNewRepository : GenericRepository<New>, INewRepository
    {
        public EfNewRepository(TContext context) : base(context)
        {
        }

        public List<New> GetNewsListWithCategory()
        {
            return _context.News.Include(b => b.Category).ToList();
        }
        public List<New> GetListWithCategoryByWriter(int id)
        {
            return _context.News.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
        }
    }
}
