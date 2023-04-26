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
    public class WriterTaskManager : IWriterTaskService
    {
        private readonly IWriterTaskRepository _writerTaskRepository;

        public WriterTaskManager(IWriterTaskRepository writerTaskRepository)
        {
            _writerTaskRepository = writerTaskRepository;
        }

        public List<int> GetCountAsync(Expression<Func<WriterTask, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<WriterTask> GetWriterTaskList(int id)
        {
            return _writerTaskRepository.GetByFilter(x => x.WriterID == id);
        }

        public void TAdd(WriterTask entity)
        {
            _writerTaskRepository.Add(entity);
        }

        public void TDelete(WriterTask entity)
        {
            _writerTaskRepository.Delete(entity);
        }

        public List<WriterTask> TGetByFilter(Expression<Func<WriterTask, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<WriterTask> TGetByFilterAsync(Expression<Func<WriterTask, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public WriterTask TGetByID(int id)
        {
           return  _writerTaskRepository.GetByID(id);
        }

        public List<WriterTask> TGetList()
        {
            return _writerTaskRepository.GetList();
        }

        public List<WriterTask> TGetListAll(Expression<Func<WriterTask, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<WriterTask>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterTask entity)
        {
           _writerTaskRepository.Update(entity);
        }

        Task<int> IGenericService<WriterTask>.GetCountAsync(Expression<Func<WriterTask, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
