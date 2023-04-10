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
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public List<int> GetCountAsync(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message entity)
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetByFilter(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Message TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetList()
        {
            return _messageRepository.GetList();
        }

        public List<Message> TGetListAll(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message entity)
        {
            throw new NotImplementedException();
        }
        public List<Message> GetInboxListByWriter(string p)
        {
            return _messageRepository.GetByFilter(x => x.Receiver == p);
        }

        List<WriterMessage> IMessageService.GetInboxListByWriter(string p)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericService<Message>.GetCountAsync(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
