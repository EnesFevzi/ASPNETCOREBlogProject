using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class WriterUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<WriterTask> Tasks { get; set; }

        //public virtual ICollection<WriterMessage> WriterSender { get; set; }
        //public virtual ICollection<WriterMessage> WriterReceiver { get; set; }
    }
}
