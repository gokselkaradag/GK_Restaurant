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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SingalRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new SingalRContext();
            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
