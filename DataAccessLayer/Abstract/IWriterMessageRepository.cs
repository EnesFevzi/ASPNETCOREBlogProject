using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Abstract
{
    public interface IWriterMessageRepository:IGenericRepository<WriterMessage>
    {
        public List<WriterMessage> GetInboxtWithMessageByWriter(int id);
        public List<WriterMessage> GetSendBoxWithMessageByWriter(int id);
    }
}
