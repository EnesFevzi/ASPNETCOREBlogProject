using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class New
    {
        [Key]
        public int NewID { get; set; }
        public string NewTitle { get; set; }
        public string NewContent { get; set; }
        public string NewThumbnailImage { get; set; }
        public string NewImage { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public bool NewStatus { get; set; }

        //Navigation Prop

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public WriterUser Writer { get; set; }
    }
}
