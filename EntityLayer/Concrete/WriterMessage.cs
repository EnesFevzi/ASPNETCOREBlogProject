using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class WriterMessage
    {
        [Key]
        public int WriterMessageID { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }

        public int SenderUserId { get; set; }
        public WriterUser WriterSender { get; set; }
        public int ReceiverUserId { get; set; }
        public WriterUser WriterReceiver { get; set; }


    }
}
