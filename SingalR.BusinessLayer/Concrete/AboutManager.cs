using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Abstract;
using SingalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAbuotDal _abuotDal;

        public AboutManager(IAbuotDal abuotDal)
        {
            _abuotDal = abuotDal;
        }

        public void TAdd(About entity)
        {
            _abuotDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _abuotDal.Delete(entity);
        }

        public About TGetByID(int id)
        {
            return _abuotDal.GetByID(id);
        }

        public List<About> TGetListAll()
        {
            return _abuotDal.GetListAll();
        }

        public void TUpdate(About entity)
        {
            _abuotDal.Update(entity);
        }
    }
}
