using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T entity);
		void TDelete(T entity);
		void TUpdate(T entity);
        Task<List<T>> TGetListAsync();
        T TGetByID(int id);
        List<T> TGetList();
		List<T> TGetByFilter(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<T> TGetByFilterAsync(Expression<Func<T, bool>> filter = null);
    }
}
