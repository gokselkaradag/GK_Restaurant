using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DtoLayer.BasketDto;
using SingalR.EntityLayer.Entities;
using SingalRApi.Model;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SingalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(x => x.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                MenuTableID = z.MenuTableID,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName,
                Price = z.Price,
                Count = z.Count,
                TotalPrice = z.TotalPrice
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SingalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 3,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
    }
}
