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
	public class AdminManager : IGenericService<Admin>
    {
        protected readonly IAdminRepository _adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<int> GetCountAsync(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public List<Admin> TGetByFilter(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Admin TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> TGetList(int id)
        {
            throw new NotImplementedException();
        }

		public List<Admin> TGetList()
		{
			throw new NotImplementedException();
		}

		public List<Admin> TGetListAll(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
