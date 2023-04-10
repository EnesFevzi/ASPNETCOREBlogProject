using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Repository;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Concrete.EntityFramework
{
    public class EfNewsRepository : GenericRepository<News>, INewsRepository
    {
        public EfNewsRepository(TContext context) : base(context)
        {
        }
    }
}
