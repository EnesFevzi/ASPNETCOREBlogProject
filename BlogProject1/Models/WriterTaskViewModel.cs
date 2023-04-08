namespace ASPNETCOREBlogProject.Models
{
    public class WriterTaskViewModel
    {
        public int WriterTaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsApproved { get; set; }
    }
}
