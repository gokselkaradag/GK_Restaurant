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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(SingalRContext context) : base(context)
        {
        }
    }
}
