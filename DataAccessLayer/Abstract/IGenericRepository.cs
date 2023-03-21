using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetListAll();
        T GetByID(int id);
        List<T> GetList();
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAllAsync(Expression<Func<T, bool>> filter);
    }
}
