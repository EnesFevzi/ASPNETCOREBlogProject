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
    public class CategoryManager : ICategoryService
    {
		protected readonly ICategoryRepository _categoryRepository;

		public CategoryManager(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

        public async Task<int> GetCountAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await _categoryRepository.GetCountAsync(filter);
        }

        public void TAdd(Category entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetByFilter(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetList()
        {
            return _categoryRepository.GetListAll();
        }

        public List<Category> TGetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetListAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category entity)
        {
            throw new NotImplementedException();
        }
        public List<Category> GetList()
        {
            return _categoryRepository.GetListAll();
        }

        
    }
}
