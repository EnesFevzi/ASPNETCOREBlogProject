using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
	public class Message
	{
        public int MessageID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }

        //public AppUser SenderUser { get; set; }
        //public int? SenderUserId { get; set; }
        //public AppUser ReceiverUser { get; set; }
        //public int? ReceiverUserId { get; set; }
    }
}
