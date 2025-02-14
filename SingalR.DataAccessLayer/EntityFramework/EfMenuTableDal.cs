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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SingalRContext context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            using var context = new SingalRContext();
            var value = context.MenuTables.Where(i => i.MenuTableID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            using var context = new SingalRContext();
            var value = context.MenuTables.Where(i => i.MenuTableID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
            using var context = new SingalRContext();
            return context.MenuTables.Count();
        }
    }
}
