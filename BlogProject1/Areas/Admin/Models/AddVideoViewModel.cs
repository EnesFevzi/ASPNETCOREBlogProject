using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREBlogProject.Areas.Admin.Models
{
    public class AddVideoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string VideoTitle { get; set; }


        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string VideoContent { get; set; }


        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        //public string PictureURL { get; set; }

        [Display(Name = "Video Dosyası")]
        //public IFormFile PictureFile { get; set; }
        public string VideoURL { get; set; }

        //[Display(Name = "Video Dosyası")]
        public IFormFile Video { get; set; }

        //public byte[] Data { get; set; }
        public int CategoryID { get; set; }
        public int WriterID { get; set; }


    }

    
}
