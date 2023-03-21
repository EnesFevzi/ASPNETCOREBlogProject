using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Abstract
{
    public interface IWriterMessageService:IGenericService<WriterMessage>
    {
        List<WriterMessage> GetInboxListByWriter(int id);
        List<WriterMessage> GetSendBoxListByWriter(int id);

        List<WriterMessage> GetListSenderMessage(string p);
        List<WriterMessage> GetListReceiverMessage(string p);
        //List<Message2> GetInboxListByWriter(string p);



    }
}
