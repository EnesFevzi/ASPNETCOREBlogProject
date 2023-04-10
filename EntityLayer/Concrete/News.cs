using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public string NewsThumbnailImage { get; set; }
        public string NewsImage { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public bool NewsStatus { get; set; }

        //Navigation Prop

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
