using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SingalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SingalRContext();
            var values = context.Products.Include(x =>  x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SingalRContext();
            return context.Products.Count();
        }

        public int ProductCountCategoryNameDrink()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.CategoryID ==(context.Categories.Where(y => y.CategoryName == "Drink").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountCategoryNameHamburger()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SingalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByHamburger()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(z => z.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }
    }
}

