using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        public List<Notification> GetNotifications() => NotificationDAO.Instance.GetNotifications();
        public Notification GetNotificationById(int notificationId) => NotificationDAO.Instance.GetNotificationById(notificationId);
        public void SaveNotification(Notification notification) => NotificationDAO.Instance.SaveNotification(notification);
        public void UpdateNotification(Notification notification) => NotificationDAO.Instance.UpdateNotification(notification);
        public void DeleteNotification(Notification notification) => NotificationDAO.Instance.DeleteNotification(notification);
    }
}
