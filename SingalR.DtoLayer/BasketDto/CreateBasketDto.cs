using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
