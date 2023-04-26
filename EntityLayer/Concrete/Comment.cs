using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.EntityLayer.Concrete
{
	public class Comment
	{
		public int CommentID { get; set; }
		public string CommentUserName { get; set; }
		public string CommentTitle { get; set; }
		public string CommnetContent { get; set; }
		public DateTime CommentDate { get; set; }
		public bool CommentStatus { get; set; }

        public int BlogScore2 { get; set; }

		//Navigation Prop

		[ForeignKey("BlogID")]
		public int BlogID { get; set; }
		public Blog Blog { get; set; }





	}
}
