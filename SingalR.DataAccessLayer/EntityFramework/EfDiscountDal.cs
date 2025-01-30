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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SingalRContext context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            using var context = new SingalRContext();
            var values = context.Discounts.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            using var context = new SingalRContext();
            var values = context.Discounts.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            using var context = new SingalRContext();
            var value = context.Discounts.Where(x => x.Status == true).ToList();
            return value;
        }
    }
}
