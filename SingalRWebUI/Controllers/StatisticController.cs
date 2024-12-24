using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
