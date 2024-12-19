using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexTwo()
        {
            return View();
        }
    }
}
