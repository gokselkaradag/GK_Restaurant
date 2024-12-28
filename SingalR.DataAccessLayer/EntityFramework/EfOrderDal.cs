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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SingalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SingalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SingalRContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            //using var context = new SingalRContext();
            //return context.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y => y.TotalPrice);
            return 0;
        }

        public int TotalOrderCount()
        {
            using var context = new SingalRContext();
            return context.Orders.Count();
        }
    }
}
