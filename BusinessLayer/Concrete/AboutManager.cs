using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutRepository _aboutRepository;

		public AboutManager(IAboutRepository aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public List<int> GetCountAsync(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(About entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About entity)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetByFilter(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public About TGetByID(int id)
        {
            throw new NotImplementedException();
        }

		public List<About> TGetList()
		{
			return _aboutRepository.GetList();
		}

		public List<About> TGetListAll(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
