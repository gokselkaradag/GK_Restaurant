using SingalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();

        int TProductCount();
        int TProductCountCategoryNameHamburger();
        int TProductCountCategoryNameDrink();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductPriceByHamburger();
        decimal TProductPriceBySteakBurger();
        List<Product> TGetLast6Products();
    }
}
