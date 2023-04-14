using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Abstract
{
    public interface IVideoRepository: IGenericRepository<Video>
    {
        List<Video> GetVideosListWithCategory();
        List<Video> GetListWithCategoryByWriter(int id);

    }
}
