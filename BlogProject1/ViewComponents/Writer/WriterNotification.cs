using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository(new TContext()));

        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.TGetList();
            return View(values);
        }
    }
}
