using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public bool CategoryStatus { get; set; }

		//Navigation Prop
		public List<Blog> Blog { get; set; }
		public List<News> News { get; set; }
		public List<Video> Video { get; set; }
	}
}
