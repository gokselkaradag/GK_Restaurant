﻿using SingalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
         int CategoryCount();
         int ActiveCategoryCount();
         int PassiveCategoryCount();
        
    }
}
