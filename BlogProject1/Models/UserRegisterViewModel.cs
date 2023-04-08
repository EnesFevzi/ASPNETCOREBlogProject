﻿using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREBlogProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı Girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Yükleyiniz")]
        //public string ImageUrl { get; set; }
        public string PictureURL { get; set; }
        public IFormFile? Picture { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi Girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar Girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen mail Girin")]
        public string Mail { get; set; }
    }
}
