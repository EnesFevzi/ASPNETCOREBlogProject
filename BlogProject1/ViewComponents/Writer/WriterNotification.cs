using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        protected readonly NotificationManager _notificationManager;

        public WriterNotification(NotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.TGetList();
            return View(values);
        }
    }
}
