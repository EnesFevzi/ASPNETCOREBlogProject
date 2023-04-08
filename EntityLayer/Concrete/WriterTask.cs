using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class WriterTask
    {
        [Key]
        public int WriterTaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskCreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompleted { get; set; }


        [ForeignKey("WriterID")]
        public int WriterID { get; set; }
        public WriterUser Writer { get; set; }
    }
}
