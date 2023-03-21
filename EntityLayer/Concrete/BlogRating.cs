using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
	public class BlogRating
    {
        [Key]
        public int BlogRaytingID { get; set; }
        public int BlogID { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRaytingCount { get; set; }
        public double BlogRaytingAverage { get; set; }
    }
}
