﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
