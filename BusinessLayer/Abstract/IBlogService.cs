using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Abstract
{
	public interface IBlogService:IGenericService<Blog>
	{
        List<Blog> GetBlogsListWithCategory();
        List<Blog> GetBlogByID(int id);
        List<Blog> GetBlogsListWithWriter(int id);
        List<Blog> GetBlogsListWithComments(int id);

    }
}
