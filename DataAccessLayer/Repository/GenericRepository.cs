using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly TContext _context;


		public GenericRepository(TContext context)
		{
			_context = context;
		}

        public void Add(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return await _context.Set<T>().CountAsync();
            else
                return await _context.Set<T>().Where(filter).CountAsync();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetListAllAsync(Expression<Func<T, bool>> filter)
        {
             return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
