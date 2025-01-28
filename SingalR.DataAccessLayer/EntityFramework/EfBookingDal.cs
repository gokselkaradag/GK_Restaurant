using SingalR.DataAccessLayer.Abstract;
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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SingalRContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new SingalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new SingalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
