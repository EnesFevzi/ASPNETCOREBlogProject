using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Concrete
{
    public class WriterUserManager : IWriterUserService
    {
        private readonly IWriterUserRepository _userRepository;

        public WriterUserManager(IWriterUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<int> GetCountAsync(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(WriterUser entity)
        {
            _userRepository.Add(entity);
        }

        public void TDelete(WriterUser entity)
        {
            _userRepository.Delete(entity);
        }

        public List<WriterUser> TGetByFilter(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public WriterUser TGetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public List<WriterUser> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetListAll(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser entity)
        {
           _userRepository.Update(entity);
        }
        public List<WriterUser> GetWriterByID(int id)
        {
            return _userRepository.GetByFilter(x => x.Id == id);
        }

        Task<int> IGenericService<WriterUser>.GetCountAsync(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
