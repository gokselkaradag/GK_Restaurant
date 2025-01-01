using Microsoft.AspNetCore.SignalR;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;

namespace SingalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var valuetwo = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", valuetwo);

            var valueactive = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", valueactive);

            var valuepas = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", valuepas);
        }
    }
}
