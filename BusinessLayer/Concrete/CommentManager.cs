using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
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
    public class CommentManager : ICommentService
	{
      protected readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<int> GetCountAsync(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment entity)
        {
            _commentRepository.Add(entity);
        }

        public void TDelete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentRepository.GetByFilter(filter);
        }

        public Comment TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetList(int id)
        {
            return _commentRepository.GetByFilter(x => x.BlogID == id);
        }

		public List<Comment> TGetList()
		{
			throw new NotImplementedException();
		}

		public List<Comment> TGetListAll(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }
        
        public List<Comment> GetCommentWithBlog()
        {
            return _commentRepository.GetListWithBlog();
        }

        Task<int> IGenericService<Comment>.GetCountAsync(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetListByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> TGetByFilterAsync(Expression<Func<Comment, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
