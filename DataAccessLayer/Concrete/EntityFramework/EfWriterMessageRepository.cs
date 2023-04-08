using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Repository;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Concrete.EntityFramework
{
    public class EfWriterMessageRepository : GenericRepository<WriterMessage>, IWriterMessageRepository
    {
        public EfWriterMessageRepository(TContext context) : base(context)
        {

        }

        public List<WriterMessage> GetInboxtWithMessageByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> GetSendBoxWithMessageByWriter(int id)
        {
            throw new NotImplementedException();
        }
        //public List<WriterMessage> GetInboxtWithMessageByWriter(int id)
        //{
        //    return _context.WriterMessages.Include(x => x.SenderUser).Where(y => y.ReceiverUserId == id).ToList();
        //}

        //public List<WriterMessage> GetSendBoxWithMessageByWriter(int id)
        //{
        //   return _context.WriterMessages.Include(x => x.ReceiverUser).Where(x => x.SenderUserId == id).ToList();
        //}

    }
}
