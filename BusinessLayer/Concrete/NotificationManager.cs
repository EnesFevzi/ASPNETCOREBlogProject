using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        protected readonly INotificationRepository _notificationRepository;

        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public List<int> GetCountAsync(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public List<Notification> TGetByFilter(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> TGetByFilterAsync(Expression<Func<Notification, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Notification TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> TGetList()
        {
            return _notificationRepository.GetList();
        }

        public List<Notification> TGetListAll(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericService<Notification>.GetCountAsync(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
