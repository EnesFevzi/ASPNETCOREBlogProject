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
    public class EfVideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public EfVideoRepository(TContext context) : base(context)
        {
        }

        public List<Video> GetVideosListWithCategory()
        {
            return _context.Videos.Include(b => b.Category).ToList();
        }
        public List<Video> GetListWithCategoryByWriter(int id)
        {
            return _context.Videos.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
        }
    }
}
