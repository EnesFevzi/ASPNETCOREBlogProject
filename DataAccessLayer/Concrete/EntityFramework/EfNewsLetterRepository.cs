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
	public class EfNewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterRepository
	{
		public EfNewsLetterRepository(TContext context) : base(context)
		{
		}
	}
}
