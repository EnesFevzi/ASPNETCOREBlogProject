using BlogProject1.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCOREBlogProject.Models
{
    public class AddCommentViewModel
    {
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommnetContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        [ForeignKey("BlogID")]
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
