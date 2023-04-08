using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Abstract
{
	public interface ICommentRepository:IGenericRepository<Comment>
	{
        List<Comment> GetListWithBlog();
    }
}
