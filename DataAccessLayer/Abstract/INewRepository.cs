using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Abstract
{
    public interface INewRepository:IGenericRepository<New>
    {
        List<New> GetNewsListWithCategory();
        List<New> GetListWithCategoryByWriter(int id);
    }
}
