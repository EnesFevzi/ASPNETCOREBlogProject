using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository(new TContext()));
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = notificationManager.TGetList();
            return View(values);
        }
    }
}
