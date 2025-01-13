using Microsoft.AspNetCore.SignalR;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;

namespace SingalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
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

            var valuepro = _productService.TProductCountCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountCategoryNameHamburger", valuepro);

            var valueprodrink = _productService.TProductCountCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountCategoryNameDrink", valueprodrink);

            var valueavg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", valueavg.ToString("0.00") + "₺");

            var valuemax = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", valuemax);

            var valuemin = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", valuemin);

            var valuehamburger = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductPriceByHamburger", valuehamburger.ToString("0.00") + "₺");

            var valueorder = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", valueorder);

            var valueactiveorder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", valueactiveorder);

            var valuelastorder = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", valuelastorder.ToString("0.00") + "₺");

            var valuemoney = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", valuemoney.ToString("0.00") + "₺");

            var valuemenu = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", valuemenu);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var valueorder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", valueorder);

            var valuemenu = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", valuemenu);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        } 
    }
}
