using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<WriterMessage> GetInboxListByWriter(string p);


    }
}
