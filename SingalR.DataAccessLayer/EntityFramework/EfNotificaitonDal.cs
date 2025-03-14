﻿using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DataAccessLayer.Repositories;
using SingalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DataAccessLayer.EntityFramework
{
    public class EfNotificaitonDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificaitonDal(SingalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SingalRContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SingalRContext();
            return context.Notifications.Where(x => x.Status == false).Count();
            
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new SingalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new SingalRContext();
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
