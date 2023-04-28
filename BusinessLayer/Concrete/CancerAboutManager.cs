using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Concrete
{
	public class CancerAboutManager : ICancerAboutService
	{
		private readonly ICancerAboutRepository _canceraboutRepository;

		public CancerAboutManager(ICancerAboutRepository canceraboutRepository)
		{
			_canceraboutRepository = canceraboutRepository;
		}

		public async Task<int> GetCountAsync(Expression<Func<CancerAbout, bool>> filter = null)
		{
			return await _canceraboutRepository.GetCountAsync(filter);
		}

		public void TAdd(CancerAbout entity)
		{
			_canceraboutRepository.Add(entity);
		}

		public void TDelete(CancerAbout entity)
		{
			_canceraboutRepository.Delete(entity);
		}

		public List<CancerAbout> TGetByFilter(Expression<Func<CancerAbout, bool>> filter)
		{
			return _canceraboutRepository.GetByFilter(filter);
		}

		public Task<CancerAbout> TGetByFilterAsync(Expression<Func<CancerAbout, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public CancerAbout TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<CancerAbout> TGetList()
		{
			return _canceraboutRepository.GetList();
		}

		public async Task<List<CancerAbout>> TGetListAsync()
		{
			return await _canceraboutRepository.GetListAsync();
		}

		public void TUpdate(CancerAbout entity)
		{
			_canceraboutRepository.Update(entity);
		}
	}
}
