using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BlogProject1.BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
	    private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogRepository.GetByFilter(x => x.BlogID == id);
        }
        public List<Blog> GetBlogsListWithCategory()
        {
            return _blogRepository.GetBlogsListWithCategory();
        }

        public async Task<int> GetCountAsync(Expression<Func<Blog, bool>> filter = null)
        {
            return await _blogRepository.GetCountAsync(filter);
        }

        public void TAdd(Blog entity)
        {
            _blogRepository.Add(entity);    
        }

        public void TDelete(Blog entity)
        {
            _blogRepository.Delete(entity);
        }

        public List<Blog> TGetByFilter(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Blog TGetByID(int id)
        {
           return _blogRepository.GetByID(id);
        }

        public List<Blog> TGetList()
        {
            return _blogRepository.GetList();
        }

        public List<Blog> TGetListAll(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog entity)
        {
            _blogRepository.Update(entity);
        }
        public List<Blog> GetBlogsListWithWriter(int id)
        {
            return _blogRepository.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogsListWithComments(int id)
        {
            return _blogRepository.GetBlogsListWithComments(id);
        }

    }
}
