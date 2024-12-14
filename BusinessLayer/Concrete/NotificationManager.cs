using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using DataEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void NotificationDelete(Notification notificationdal)
        {
            _notificationDal.Delete(notificationdal);   
        }

        public List<Notification> GetList()
        {
          return  _notificationDal.GetAll();
        }

        public void NoticationAdd(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void NotificationUpdate(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        
    }
}
