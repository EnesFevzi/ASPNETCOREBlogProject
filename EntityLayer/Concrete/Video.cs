using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string VideoContent { get; set; }
        public string VideoThumbnailImage { get; set; }
        public string VideoImage { get; set; }
        public DateTime VideoCreateDate { get; set; }
        public bool VideoStatus { get; set; }

        //Navigation Prop

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
