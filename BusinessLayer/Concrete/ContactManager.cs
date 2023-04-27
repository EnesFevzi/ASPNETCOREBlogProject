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
    public class ContactManager : IContactService
    {
        protected readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> GetCountAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _contactRepository.GetCountAsync(filter);
        }

        public void TAdd(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void TDelete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetByFilter(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> TGetByFilterAsync(Expression<Func<Contact, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Contact TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetListAll(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericService<Contact>.GetCountAsync(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
