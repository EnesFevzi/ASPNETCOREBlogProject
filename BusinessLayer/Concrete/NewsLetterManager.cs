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
    public class NewsLetterManager : INewsLetterService
    {
        protected readonly INewsLetterRepository _newsLetterRepository;

        public NewsLetterManager(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }

        public async Task<int> GetCountAsync(Expression<Func<NewsLetter, bool>> filter = null)
        {
            return await _newsLetterRepository.GetCountAsync(filter);
        }

        public void TAdd(NewsLetter newsLetter)
        {
            _newsLetterRepository.Add(newsLetter);
        }

        public void TDelete(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetByFilter(Expression<Func<NewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<NewsLetter> TGetByFilterAsync(Expression<Func<NewsLetter, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public NewsLetter TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetListAll(Expression<Func<NewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsLetter>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(NewsLetter entity)
        {
            throw new NotImplementedException();
        }


    }
}
