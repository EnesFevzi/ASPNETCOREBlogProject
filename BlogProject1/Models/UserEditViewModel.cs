namespace ASPNETCOREBlogProject.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //public string UserName { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PictureURL { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
