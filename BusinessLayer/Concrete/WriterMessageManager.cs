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
    public class WriterMessageManager : IWriterMessageService
    {
        private readonly IWriterMessageRepository _message2Repository;

        public WriterMessageManager(IWriterMessageRepository message2Repository)
        {
            _message2Repository = message2Repository;
        }

        public List<int> GetCountAsync(Expression<Func<WriterMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(WriterMessage entity)
        {
            _message2Repository.Add(entity);
        }

        public void TDelete(WriterMessage entity)
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> TGetByFilter(Expression<Func<WriterMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public WriterMessage TGetByID(int id)
        {
            return _message2Repository.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _message2Repository.GetList();
        }

        public List<WriterMessage> TGetListAll(Expression<Func<WriterMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage entity)
        {
            throw new NotImplementedException();
        }
        public List<WriterMessage> GetInboxListByWriter(int id)
        {
           return _message2Repository.GetInboxtWithMessageByWriter(id);
        }
        public List<WriterMessage> GetSendBoxListByWriter(int id)
        {
            return _message2Repository.GetSendBoxWithMessageByWriter(id);
        }
        public List<WriterMessage> GetListReceiverMessage(string p)
        {
            return _message2Repository.GetByFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> GetListSenderMessage(string p)
        {
            return _message2Repository.GetByFilter(x => x.Sender == p);
        }

        async Task<int> IGenericService<WriterMessage>.GetCountAsync(Expression<Func<WriterMessage, bool>> filter)
        {
           return await  _message2Repository.GetCountAsync(filter);
        }

        public Task<List<WriterMessage>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WriterMessage> TGetByFilterAsync(Expression<Func<WriterMessage, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
