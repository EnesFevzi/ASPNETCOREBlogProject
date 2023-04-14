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
    public class NewManager : INewService
    {
        private readonly INewRepository _newRepository;

        public NewManager(INewRepository newRepository)
        {
            _newRepository = newRepository;
        }

        public List<New> GetNewsListWithWriter(int id)
        {
            return _newRepository.GetListWithCategoryByWriter(id);
        }

        public Task<int> GetCountAsync(Expression<Func<New, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<New> GetNewByID(int id)
        {
            return _newRepository.GetByFilter(x => x.NewID == id);
        }

        public List<New> GetNewListWithCategory()
        {
            return _newRepository.GetNewsListWithCategory();
        }

        public void TAdd(New entity)
        {
            _newRepository.Add(entity);
        }

        public void TDelete(New entity)
        {
            _newRepository.Delete(entity);
        }

        public List<New> TGetByFilter(Expression<Func<New, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public New TGetByID(int id)
        {
            return _newRepository.GetByID(id);
        }

        public List<New> TGetList()
        {
            return _newRepository.GetList();
        }

        public List<New> TGetListAll(Expression<Func<New, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(New entity)
        {
            _newRepository.Update(entity);
        }
    }
}
