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
    public class VideoManager : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoManager(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public Task<int> GetCountAsync(Expression<Func<Video, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetVideoByID(int id)
        {
            return _videoRepository.GetByFilter(x => x.VideoID == id);
        }

        public List<Video> GetVideosListWithCategory()
        {
            return _videoRepository.GetVideosListWithCategory();
        }

        public List<Video> GetVideosListWithWriter(int id)
        {
            return _videoRepository.GetListWithCategoryByWriter(id);
        }

        public void TAdd(Video entity)
        {
            _videoRepository.Add(entity);
        }

        public void TDelete(Video entity)
        {
            throw new NotImplementedException();
        }

        public List<Video> TGetByFilter(Expression<Func<Video, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Video> TGetByFilterAsync(Expression<Func<Video, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Video TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Video> TGetListAll(Expression<Func<Video, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Video>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Video entity)
        {
            throw new NotImplementedException();
        }
    }
}
