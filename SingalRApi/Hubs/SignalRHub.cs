using Microsoft.AspNetCore.SignalR;
using SingalR.DataAccessLayer.Concrete;

namespace SingalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        SingalRContext context = new SingalRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
